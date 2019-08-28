using System.Collections.Generic;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public User HeadOfProject { get; set; }
        public int HeadOfProjectId { get; set; }
        public ICollection<User> Members { get; set; }
        public float SpentHours { get; set; }

    }
}