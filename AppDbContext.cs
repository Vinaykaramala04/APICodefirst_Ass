using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using APICodeFrst_Ass1.Models;


namespace APICodeFrst_Ass1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: One Project -> Many Employees
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Decimal precision config
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Project>()
                .Property(p => p.Budget)
                .HasColumnType("decimal(18,2)");

            // Seeding data
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    ProjectCode = "PRJ001",
                    ProjectName = "AI Development",
                    StartDate = new DateTime(2025, 1, 10),
                    EndDate = null,
                    Budget = 500000m
                },
                new Project
                {
                    ProjectId = 2,
                    ProjectCode = "PRJ002",
                    ProjectName = "Web API Upgrade",
                    StartDate = new DateTime(2025, 2, 1),
                    EndDate = null,
                    Budget = 250000m
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeCode = "EMP0001",
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Designation = "Software Engineer",
                    Salary = 60000m,
                    ProjectId = 1
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeCode = "EMP0002",
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Designation = "Project Manager",
                    Salary = 90000m,
                    ProjectId = 2
                }
            );
        }
    }
}
