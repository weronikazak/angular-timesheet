using System.Collections.Generic;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}