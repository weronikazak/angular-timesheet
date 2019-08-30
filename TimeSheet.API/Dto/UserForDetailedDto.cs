using System;
using System.Collections.Generic;
using TimeSheet.API.Data;

namespace TimeSheet.API.Dto
{
    public class UserForDetailedDto
    {
         public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }
        public Project LastProject { get; set; }
        public int LastProjectId { get; set; }
        public ICollection<Project> MyProperty { get; set; }
    }
}