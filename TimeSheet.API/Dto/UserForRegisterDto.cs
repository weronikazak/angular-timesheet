using System;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage= "Hasło powinno zawierać od 4 do 8 znaków")]
        public string Password { get; set; }
    }
}