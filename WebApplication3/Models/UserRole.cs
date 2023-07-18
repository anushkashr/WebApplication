//using System.ComponentModel.DataAnnotations; kept in Program.cs as a global declaration 

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class UserRole
    {

        [Key] 
        public int RoleID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]

        public string RoleName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string RoleDesc { get; set; }


    }
}
