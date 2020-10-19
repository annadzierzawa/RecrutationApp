using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recrutation_App.Application.Commands;
using Recrutation_App.Application.DTOs;
using Recrutation_App.Application.Queries;
using Recrutation_App.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recrutation_App.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompanyController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCompany(AddCompanyCommand command)
        {
            var id = await _companiesService.AddCompany(command);

            return Ok(id);
        }

        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<CompanySearchDTO> SearchCompany(SearchCompanyQuery query)
        {
            var result = await _companiesService.SearchCompany(query);

            return result;
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompany(long id, UpdateCompanyCommand command)
        {
            command.Id=id;
            await _companiesService.UpdateCompany(command);
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public void DeleteCompany(long id)
        {
             _companiesService.DeleteCompany(id);
        }
    }

}
