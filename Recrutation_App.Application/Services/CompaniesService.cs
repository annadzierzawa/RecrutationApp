using Recrutation_App.Application.Commands;
using Recrutation_App.Application.DTOs;
using Recrutation_App.Application.Queries;
using Recrutation_App.Application.Repositories;
using Recrutation_App.Domain.Entities;
using Recrutation_App.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recrutation_App.Application.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<long> AddCompany(AddCompanyCommand command)
        {
            var company = new Company() {
                Name = command.Name,
                EstablishmentYear = command.EstablishmentYear,
                Employees = command.Employees.Select(e =>
                {
                    var employee = new Employee() {
                        DateOfBirth = e.DateOfBirth,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = JobTitleHelper.GetEnumFromString(e.JobTitle)
                    };
                    return employee;
                }).ToList()
            };
           return await _companiesRepository.AddCompany(company);
        }

        public void DeleteCompany(long id)
        {
            _companiesRepository.DeleteCompany(id);
        }

        public async Task<CompanySearchDTO> SearchCompany(SearchCompanyQuery query)
        {
            var result = await _companiesRepository.Search(query);
            var companies = new CompanySearchDTO()
            {
                Results = result.Select(c =>
                {
                    var company = new CompanyDTO()
                    {
                        EstablishmentYear = c.EstablishmentYear,
                        Name = c.Name,
                        Employees = c.Employees.Select(e =>
                        {
                            var employee = new EmployeeDTO()
                            {
                                DateOfBirth = e.DateOfBirth,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                JobTitle = e.JobTitle.ToString("g")
                            };
                            return employee;
                        }).ToList()
                    };
                    return company;
                })
            };
            return companies;
        }

        public async Task UpdateCompany(UpdateCompanyCommand command)
        {
            await _companiesRepository.UpdateCompany(command);
        }
    }
}
