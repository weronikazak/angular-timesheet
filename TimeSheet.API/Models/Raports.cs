using System;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Raports
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime WorkTo { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string Comment { get; set; }
    }
}