using System;
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

        public async Task<IEnumerable<Project>> GetProjectsForGroup(int groupId)
        {
                return await _context.Projects
                .Where(u => u.Id == groupId).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsForCompany(int companyId)
        {
            return await _context.Projects
                .Where(u => u.CompanyId == companyId)
                // .OrderByDescending(u => u.ProjectStart)
                .ToListAsync();
        }

        public async Task<IEnumerable<Raports>> GetAllRaports()
        {
            return await _context.Raports.Include(u => u.User).Include(u => u.Project).Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<IEnumerable<Raports>> GetRaportsForToday()
        {
            return await _context.Raports.Include(u => u.User).Include(u => u.Project).Include(u => u.Role)
                .Where(u => u.WorkFrom.Date == new DateTime().Date).ToListAsync();
        }

        public async Task<IEnumerable<Raports>> GetRaportsForTodayForUser(int userId)
        {
            return await _context.Raports.Include(u => u.User).Include(u => u.Project).Include(u => u.Role)
                .Where(u => u.WorkFrom.Date == new DateTime() && u.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Raports>> GetRaportsForProject(int projectId)
        {
            return await _context.Raports.Include(u => u.User).Include(u => u.Project).Include(u => u.Role)
                .Where(u => u.ProjectId == projectId).ToListAsync();
        }

        public async Task<Raports> GetRaport(int raportId)
        {
            return await _context.Raports.FirstOrDefaultAsync(u => u.Id == raportId);
        }
    }
}