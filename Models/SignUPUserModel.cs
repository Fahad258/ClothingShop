using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace clothingshopproject.Models
{
    public class SignUPUserModel
    {
        [Required(ErrorMessage = "Please Enter an FirstName")]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        

        [Required(ErrorMessage = "Please Enter an Email")]
        [Display(Name = "Email Adress")]
        [EmailAddress(ErrorMessage = "Please Enter an avalid Email")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Please Enter an strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }







        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
