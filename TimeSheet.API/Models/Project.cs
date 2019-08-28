using System;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public Company Company { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsFinished { get; set; }
        public float SpentHours { get; set; }
    }
}