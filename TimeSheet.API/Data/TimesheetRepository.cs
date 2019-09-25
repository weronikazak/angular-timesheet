using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            return companies;
        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            return company;
        }

        public async Task<Project> GetProject(int id)
        {
            var project = await _context.Projects.Include(u => u.Company).FirstOrDefaultAsync(p => p.ProjectId == id);

            return project;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            var projects = await _context.Projects.Include(u => u.Company).ToListAsync();

            return projects;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            // 0 means that nothing was saved in db
           return await _context.SaveChangesAsync() > 0;
        }
    }
}