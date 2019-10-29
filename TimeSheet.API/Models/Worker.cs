using System;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        //public DateTime TimeAdded { get; set; }
        //public float TimeSpent { get; set; }
        //public bool IsHead { get; set; }
    }
}