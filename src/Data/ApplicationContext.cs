using System;
using EntityFrameworkCore5Examples.Models.SplitQuery;
using EntityFrameworkCore5Examples.Models.TablePerType;
// using EntityFrameworkCore5Examples.Models.TablePerHierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore5Examples.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            CreateDataForSplitQueryExample(modelBuilder);

            CreateDataForTablePerHierachyExample(modelBuilder);
        }

        private void CreateDataForTablePerHierachyExample(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Billy", Email = "billy@test.com" },
                new Client { Id = 2, Name = "Avril", Email = "avril@test.com" },
                new Client { Id = 3, Name = "Sasha", Email = "sasha@test.com" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 4, Name = "Robert", UserName = "robert" },
                new User { Id = 5, Name = "Meg", UserName = "meg" },
                new User { Id = 6, Name = "Kitty", UserName = "kitty" }
            );
        }

        private void CreateDataForSplitQueryExample(ModelBuilder modelBuilder)
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