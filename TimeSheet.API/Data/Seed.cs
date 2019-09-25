using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context) {
            if (!context.Users.Any()){
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users) {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Email = user.Email;
                    context.Users.Add(user);
                }
            }

            if (!context.Companies.Any()){
                var companyData = System.IO.File.ReadAllText("Data/CompanySeedData.json");
                var companies = JsonConvert.DeserializeObject<List<Company>>(companyData);
                foreach (var company in companies) {
                    context.Companies.Add(company);
                }
            }

            // if (!context.Projects.Any()){
            //     var projectData = System.IO.File.ReadAllText("Data/ProjectSeedData.json");
            //     var projects = JsonConvert.DeserializeObject<List<Project>>(projectData);
            //     foreach (var project in projects) {
            //         context.Projects.Add(project);
            //     }
            // }

            

            context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using(var hmac = new System.Security.Cryptography.HMACSHA512()){
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

           }
        }

    }
}