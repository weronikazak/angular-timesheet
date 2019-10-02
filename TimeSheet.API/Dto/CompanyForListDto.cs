using System.Collections.Generic;
using TimeSheet.API.Data;

namespace TimeSheet.API.Dto
{
    public class CompanyForListDto
    {
        public string CompanyName { get; set; }
        public string Miasto { get; set; }
        public ICollection<Project> CompanyProjects { get; set; }
    }
}