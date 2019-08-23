using System.Collections.Generic;

namespace TimeSheet.API.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}