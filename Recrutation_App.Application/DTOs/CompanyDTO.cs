using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Application.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}
