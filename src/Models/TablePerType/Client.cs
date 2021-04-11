using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore5Examples.Models.TablePerType
{
    //[Table("Clients")]

    public class Client : Person
    {
        public string Email { get; set; }
    }
}