using Microsoft.EntityFrameworkCore;

namespace TimeSheet.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}