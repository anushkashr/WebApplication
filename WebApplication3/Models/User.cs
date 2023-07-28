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

        [Column(TypeName ="datetime")]
        public DateTime Dob { get; set; } 

        public int Age { get; set; }

        //navigation property
        //Here we are setting the ForeignKey
        [ForeignKey("UserRole")]
        public int RoleID { get; set; }


        //navigation property
        //UserRole ko class lai nai tesko object banaidiyau
        public UserRole UserRole { get; set; }
    }
}
