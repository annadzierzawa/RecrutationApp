using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Application.Queries
{
    public class SearchCompanyQuery
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public IEnumerable<string> EmployeeJobTitles { get; set; }
    }
}
