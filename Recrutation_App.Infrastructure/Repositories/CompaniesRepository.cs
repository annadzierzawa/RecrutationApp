using Microsoft.EntityFrameworkCore;
using Recrutation_App.Application.Commands;
using Recrutation_App.Application.Queries;
using Recrutation_App.Application.Repositories;
using Recrutation_App.Domain.Entities;
using Recrutation_App.Domain.Enums;
using Recrutation_App.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recrutation_App.Infrastructure.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly RecrutationContext _context;
        public CompaniesRepository(RecrutationContext context)
        {
            _context = context;
        }

        public async Task<long> AddCompany(Company company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        public void DeleteCompany(long id)
        {
            var company = _context.Companies.Find(id);

            if(company is null)
            {
                throw new Exception("Company does not exist");
            }

            _context.Remove(company);
        }


        public async Task<IEnumerable<Company>> Search(SearchCompanyQuery query)
        {
            if(query.EmployeeJobTitles == null) //to avoid null in JobTitlesList
            {
                query.EmployeeJobTitles = new List<string>();
            }

            var companies = await _context.Companies.Include(c => c.Employees).ToListAsync();

            if (!string.IsNullOrWhiteSpace(query.Keyword) && query.EmployeeDateOfBirthFrom != null && query.EmployeeDateOfBirthTo != null)
            {
                var result = companies.Where(c => c.Name.Contains(query.Keyword)
                                             || c.Employees.Any(e => e.FirstName.Contains(query.Keyword)
                                             || e.LastName.Contains(query.Keyword))
                                             || c.Employees.Any(k => (k.DateOfBirth > query.EmployeeDateOfBirthFrom && k.DateOfBirth < query.EmployeeDateOfBirthTo))
                                             || c.Employees.Any(e => query.EmployeeJobTitles.Any(s => JobTitleHelper.GetEnumFromString(s) == e.JobTitle))).ToList();
                return result;
            }
            else if (string.IsNullOrWhiteSpace(query.Keyword) && (query.EmployeeDateOfBirthFrom != null && query.EmployeeDateOfBirthTo != null))
            {
                var result = companies.Where(c =>
                                             c.Employees.Any(k => (k.DateOfBirth > query.EmployeeDateOfBirthFrom && k.DateOfBirth < query.EmployeeDateOfBirthTo))
                                             || c.Employees.Any(e => query.EmployeeJobTitles.Any(s => JobTitleHelper.GetEnumFromString(s) == e.JobTitle))).ToList();
                return result;
            }
            else if (!string.IsNullOrWhiteSpace(query.Keyword) && (query.EmployeeDateOfBirthFrom == null || query.EmployeeDateOfBirthTo == null))
            {
                var result = companies.Where(c => c.Name.Contains(query.Keyword)
                                           || c.Employees.Any(e => e.FirstName.Contains(query.Keyword)
                                           || e.LastName.Contains(query.Keyword)) 
                                           || c.Employees.Any(e => query.EmployeeJobTitles.Any(s => JobTitleHelper.GetEnumFromString(s) == e.JobTitle))).ToList();
                return result;
            }
            else if (string.IsNullOrWhiteSpace(query.Keyword) && (query.EmployeeDateOfBirthFrom == null || query.EmployeeDateOfBirthTo == null))
            {
                var result = companies.Where(c => c.Employees.Any(e => query.EmployeeJobTitles.Any(s => JobTitleHelper.GetEnumFromString(s) == e.JobTitle))).ToList();
                return result;
            }

            return new List<Company>();
        }

        public async Task UpdateCompany(UpdateCompanyCommand command)
        {
            var company = _context.Companies.Find(command.Id);

            if (company is null)
            {
                throw new Exception("Company does not exist");
            }

            company.Name = command.Name;
            company.EstablishmentYear = command.EstablishmentYear;

            await _context.SaveChangesAsync();
        }
    }
}
