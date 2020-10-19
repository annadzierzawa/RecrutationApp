using Recrutation_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Application.DTOs
{
    public class CompanySearchDTO
    {
        public IEnumerable<CompanyDTO> Results { get; set; }
    }
}
