using System;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Raports
    {
        public int RaportId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime WorkTo { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}