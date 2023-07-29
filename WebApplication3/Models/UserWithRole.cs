namespace WebApplication3.Models
{
    public class UserWithRole
    {
        [Key]
        public int UserId { get; set; } 

        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string RoleID { get; set; }

        public int RoleName { get; set; }


    }
}
