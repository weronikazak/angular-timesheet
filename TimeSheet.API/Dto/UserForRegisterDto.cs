using System.ComponentModel.DataAnnotations;

namespace TimeSheet.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage= "Hasło powinno zawierać od 4 do 8 znaków")]
        public string Password { get; set; }
    }
}