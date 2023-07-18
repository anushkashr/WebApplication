//using System.ComponentModel.DataAnnotations; kept in Program.cs as a global declaration
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]

        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
 

        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]


        public string Email { get; set; }
        [Column(TypeName = "varchar(60)")]
        [Required]

        public string Password { get; set; }
        [Column(TypeName = "varchar(50)")]
    
        public string Address { get; set; }

    }
}
