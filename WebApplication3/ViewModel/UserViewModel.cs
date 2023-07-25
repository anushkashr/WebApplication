﻿namespace WebApplication3.ViewModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }

      
        [Required]

        public string FirstName { get; set; }
     


        public string LastName { get; set; }
     
        [Required]


        public string Email { get; set; }
     
        [Required]

        public string Password { get; set; }


        public string Address { get; set; }

    }
}
