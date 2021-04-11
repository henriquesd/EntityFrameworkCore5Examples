using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore5Examples.Models.TablePerHierarchy
{
    public class Client : Person
    {
        //[Required]
        public string Email { get; set; }
    }
}