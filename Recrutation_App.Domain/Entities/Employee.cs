using Recrutation_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Domain.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }   //reference to Company
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitleEnum JobTitle { get; set; }
    }
}
