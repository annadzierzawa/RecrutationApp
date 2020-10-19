using Recrutation_App.Application.Commands;
using Recrutation_App.Application.DTOs;
using Recrutation_App.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recrutation_App.Application.Services
{
    public interface ICompaniesService
    {
        Task<long> AddCompany(AddCompanyCommand command);
        Task<CompanySearchDTO> SearchCompany(SearchCompanyQuery query);
        void DeleteCompany(long id);
        Task UpdateCompany(UpdateCompanyCommand command);
    }
}
