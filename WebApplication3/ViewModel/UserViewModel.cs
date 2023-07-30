using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using WebApplication3.Models;
using WebApplication3.Helper;

namespace WebApplication3.ViewModel
{
    public class UserViewModel: IValidatableObject
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


        [DataType(DataType.Date)]
        [DobValidationAttribute(ErrorMessage="Date of Birth cannot be today")]
        [Display(Name = "Date of Birth")]
        public string Dob { get; set; }

        [Required]
        [Range(18,50, ErrorMessage ="Age must be between 18 and 50")]
       
        public int Age { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirmation of password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "User Role")]
        public int? RoleId { get; set; }

        //declaring to use in join query
        public UserRole UserRole { get; set; }

        //loop launa milne item to show the User roles in the drop down in Create page 
        //SelectListItem is a readymade item 
        public IEnumerable<SelectListItem> UserRoles { get; set; }  

        public IQueryable<UserWithRole> Users { get; set; }

        #region ValidationRegion
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            //we can specify our custom logic here
            DateTime _dob = Convert.ToDateTime(Dob).Date;
            if(_dob > DateTime.Today)
            {
                //we can do it through a list here but then we have to insert data, store and then retrieve 
                //so we use yield because it returns values one by one
                yield return new ValidationResult("DOB cannot be greater than today");
            }
            if(_dob < DateTime.Today.AddYears(-50))
            {
                yield return new ValidationResult("DOB cannot be too past");
            }
            if(Age == 20)
            {
                yield return new ValidationResult("Age cannot be 20");
            }
        }
        #endregion


    }



}
