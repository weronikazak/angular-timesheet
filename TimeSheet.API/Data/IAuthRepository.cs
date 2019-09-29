using System.Threading.Tasks;

namespace TimeSheet.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string passowrd);
         Task<bool> UserExists(string username); //check if user already exists in database
         
    }
}