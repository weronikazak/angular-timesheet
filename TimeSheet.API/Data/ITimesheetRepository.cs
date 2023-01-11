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
        Task<IEnumerable<Project>> GetProjectsForGroup(int groupId);
        Task<IEnumerable<Project>> GetProjectsForCompany(int companyId);
        Task<IEnumerable<Raports>> GetAllRaports();
        Task<Raports> GetRaport(int raportId);
        Task<IEnumerable<Raports>> GetRaportsForToday();
        Task<IEnumerable<Raports>> GetRaportsForTodayForUser(int userId);
        Task<IEnumerable<Raports>> GetRaportsForProject(int projectId);
        Task<bool> SaveAll();
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);

    }
}