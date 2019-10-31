using System;
using System.Collections.Generic;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Raports> Raports { get; set; }
        //public DateTime? ProjectStart { get; set; }
        //public DateTime? Deadline { get; set; }
        //public bool IsFinished { get; set; }
        //public float SpentHours { get; set; }
    }
}