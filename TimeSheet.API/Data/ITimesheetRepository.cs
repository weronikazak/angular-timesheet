using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.API.Helpers;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public interface ITimesheetRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        // Task GetOne<T>(int id) where T: class;
        // Task<IEnumerable> GetList<T>()where T: class;
        Task<ICollection<Project>> GetProjectsForGroup(int groupId);
        Task<ICollection<Project>> GetProjectsForCompany(int companyId);
        Task<bool> SaveAll();
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);

    }
}