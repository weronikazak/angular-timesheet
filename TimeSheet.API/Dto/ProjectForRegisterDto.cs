using System;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.API.Dto
{
    public class ProjectForRegisterDto
    {
        [Required]
        public string ProjectName { get; set; }
        public DateTime? Deadline { get; set; }
        //public bool IsFinished { get; set; }
        //public float SpentHours { get; set; }
    }
}