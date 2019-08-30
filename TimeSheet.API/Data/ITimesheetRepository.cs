using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public interface ITimesheetRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);

    }
}