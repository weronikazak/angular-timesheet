using System.Collections.Generic;
using TimeSheet.API.Data;

namespace TimeSheet.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PrzedstawicielImie { get; set; }
        public string PrzedstawicielNazwisko { get; set; }
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}