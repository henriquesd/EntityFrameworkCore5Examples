namespace EntityFrameworkCore5Examples.Models.SplitQuery
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relation */
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}