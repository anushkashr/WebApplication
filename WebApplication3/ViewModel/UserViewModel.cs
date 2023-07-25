namespace WebApplication3.ViewModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }

      
        [Required(ErrorMessage="First Name is required field")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }
     
        [Required]
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public string Dob { get; set; }

        [Required]
        [Range(18,50, ErrorMessage ="Age must be between 18 and 50")]
       
        public string Age { get; set; }

    }
}
