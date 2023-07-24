//using System.ComponentModel.DataAnnotations; kept in Program.cs as a global declaration 

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class UserRole
    {

        [Key] 
        public int RoleID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Role Name")]
        [StringLength(10, MinimumLength =3, ErrorMessage = "Minimum 3 characters required")]
        public string RoleName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Role Description")]
        public string RoleDesc { get; set; }


    }
}
