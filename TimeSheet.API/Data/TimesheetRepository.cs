using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheet.API.Helpers;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private DataContext _context;

        public TimesheetRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        // public async Task<Group> GetWorkerGroups(int workerId) {
        //      return await _context.Groups.Where(u => u.Members.Contains(u.)).ToListAsync();
        // }

        public async Task<ICollection<Project>> GetProjectsForGroup(int groupId) {
            return await _context.Projects
                .Where(u => u.Id == groupId).ToListAsync();
        }

        public async Task<ICollection<Project>> GetProjectsForCompany(int companyId) {
            return await _context.Projects
                .Where(u => u.CompanyId == companyId)
                // .OrderByDescending(u => u.ProjectStart)
                .ToListAsync();
        }

        // public async Task<ICollection<User>> GetUsersForGroup(int groupId) {
        //     //var users = from _context.Users where groupId == 1;
        //     //return await _context.Users.Include(u => u.Groups);

        //     return await _context.Users.FindAsync(u => u.);
        // }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            return companies;
        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
            return company;
        }

        public async Task<Project> GetProject(int id)
        {
            var project = await _context.Projects.Include(u => u.Company).FirstOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            var projects = await _context.Projects.Include(u => u.Company).ToListAsync();

            return projects;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users =  _context.Users.OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

            if (!string.IsNullOrEmpty(userParams.OrderBy)) {
                switch (userParams.OrderBy) {
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            // 0 means that nothing was saved in db
           return await _context.SaveChangesAsync() > 0;
        }
    }
}