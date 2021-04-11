using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore5Examples.Models.TablePerType
{
    //[Table("People")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}