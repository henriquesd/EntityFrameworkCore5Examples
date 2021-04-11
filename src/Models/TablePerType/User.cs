using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore5Examples.Models.TablePerType
{
    //[Table("Users")]

    public class User : Person
    {
        public string UserName { get; set; }
    }
}