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
        public DbSet<Raports> Raports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Raports>()
                .HasOne(u => u.User)
                .WithMany(u => u.Raports)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Company>()
                .HasMany(u => u.Projects)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<Raports>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Raports)
                .HasForeignKey( u=> u.RoleId);

            modelBuilder.Entity<Raports>()
                .HasOne(u => u.Project)
                .WithMany(u => u.Raports)
                .HasForeignKey(u => u.ProjectId);

            
        }
    }
}