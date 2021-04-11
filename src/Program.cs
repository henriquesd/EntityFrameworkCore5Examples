using System;
using System.Linq;
using EntityFrameworkCore5Examples.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore5Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();

            QueryWithoutSplitQuery();
            QueryWithSplitQuery();

            SelectUsers();
        }

        static void CreateDatabase()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        static void SelectUsers()
        {
            using var db = new ApplicationContext();

            var users = db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name} - Username: {user.UserName}");
            }
        }

        static void QueryWithoutSplitQuery()
        {
            using var db = new ApplicationContext();

            var courses = db.Courses
                .Include(p => p.Students)
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");

                foreach (var student in course.Students)
                {
                    Console.WriteLine($"\tStudent: {student.Name}");
                }
            }
        }

        static void QueryWithSplitQuery()
        {
            using var db = new ApplicationContext();

            var courses = db.Courses
                .Include(p => p.Students)
                .AsSplitQuery()
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");

                foreach (var student in course.Students)
                {
                    Console.WriteLine($"\tStudent: {student.Name}");
                }
            }
        }
    }
}
