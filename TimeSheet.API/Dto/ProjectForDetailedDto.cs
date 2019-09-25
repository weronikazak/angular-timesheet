using System;
using TimeSheet.API.Data;
using TimeSheet.API.Models;

namespace TimeSheet.API.Dto
{
    public class ProjectForDetailedDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public DateTime? ProjectStart { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsFinished { get; set; }
    }
}