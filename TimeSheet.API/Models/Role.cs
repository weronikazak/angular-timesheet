using System.Collections.Generic;

namespace TimeSheet.API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Raports> Raports { get; set; }
    }
}