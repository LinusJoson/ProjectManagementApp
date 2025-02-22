using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjectManagementApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Adding a parameterless constructor to be used by the ApplicationDbContextFactory class
        public ApplicationDbContext() { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectManager>()
                .HasKey(pm => pm.Id); // Explicitly setting the primary key for the ProjectManager entity. This is because of the error message regarding the primary key not being set. Should hopefully fix the issue and make the migration work?

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ServiceType)
                .WithMany()
                .HasForeignKey(p => p.ServiceTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
