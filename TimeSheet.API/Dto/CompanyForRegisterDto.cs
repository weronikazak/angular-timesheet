using System.ComponentModel.DataAnnotations;

namespace TimeSheet.API.Dto
{
    public class CompanyForRegisterDto
    {
        [Required]
        public string CompanyName { get; set; }
        public string PrzedstawicielImie { get; set; }
        public string PrzedstawicielNazwisko { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public string Miasto { get; set; }
        [Required]
        [MinLength(4), MaxLength(7)]
        public string KodPocztowy { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
    }
}