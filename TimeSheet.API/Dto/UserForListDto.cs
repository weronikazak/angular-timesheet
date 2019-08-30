using System;

namespace TimeSheet.API.Dto
{
    public class UserForListDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime LastActive { get; set; }
    }
}