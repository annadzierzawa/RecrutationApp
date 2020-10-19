using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Domain.Entities
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
