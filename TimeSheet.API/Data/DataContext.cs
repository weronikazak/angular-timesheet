using Microsoft.EntityFrameworkCore;
using TimeSheet.API.Models;

namespace TimeSheet.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Worker>()
                .HasOne(u => u.User)
                .WithMany(u => u.Workers)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Company>()
                .HasMany(u => u.Projects)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<Worker>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Workers)
                .HasForeignKey( u=> u.RoleId);

            modelBuilder.Entity<Worker>()
                .HasOne(u => u.Project)
                .WithMany(u => u.Workers)
                .HasForeignKey(u => u.ProjectId);

            
        }
    }
}