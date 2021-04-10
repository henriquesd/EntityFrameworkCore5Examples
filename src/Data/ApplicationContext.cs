using System;
using EntityFrameworkCore5Examples.Models.SplitQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore5Examples.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=EntityFrameworkCore5Examples;Integrated Security=true;pooling=true;";
            optionsBuilder
                .UseSqlServer(strConnection)
                //.UseSqlServer(strConnection, p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Information Systems" },
                new Course { Id = 2, Name = "Computer Science" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John", CourseId = 1 },
                new Student { Id = 2, Name = "Mark", CourseId = 1 },
                new Student { Id = 3, Name = "Luke", CourseId = 2 }
            );
        }
    }
}