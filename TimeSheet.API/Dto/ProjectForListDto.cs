using System;

namespace TimeSheet.API.Dto
{
    public class ProjectForListDto
    {
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ProjectStart { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsFinished { get; set; }
    }
}