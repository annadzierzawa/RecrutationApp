using Recrutation_App.Application.Commands;
using Recrutation_App.Application.Queries;
using Recrutation_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recrutation_App.Application.Repositories
{
    public interface ICompaniesRepository
    {
        Task<long> AddCompany(Company company);
        Task<IEnumerable<Company>> Search(SearchCompanyQuery query);
        public void DeleteCompany(long id);
        Task UpdateCompany(UpdateCompanyCommand command);
    }
}
