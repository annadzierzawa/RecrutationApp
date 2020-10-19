using Recrutation_App.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recrutation_App.Application.Commands
{
    public class AddCompanyCommand
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(1000,2021)]
        public int EstablishmentYear { get; set; }

        public IEnumerable<EmployeeDTO> Employees { get; set; }

    }
}
