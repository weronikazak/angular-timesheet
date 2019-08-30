using System;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public DateTime TimeAdded { get; set; }
        public float TimeSpent { get; set; }
    }
}