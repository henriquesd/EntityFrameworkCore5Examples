using System.Collections.Generic;
using EntityFrameworkCore5Examples.Models.SplitQuery;

namespace EntityFrameworkCore5Examples.Models.SplitQuery
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relations */
        public IEnumerable<Student> Students { get; set; }
    }
}