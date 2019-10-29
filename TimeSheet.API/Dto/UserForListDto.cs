using System;

namespace TimeSheet.API.Dto
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string UserPhoto { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime LastActive { get; set; }
    }
}