using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MapsEditor.Domain.Models
{
  public class RegistrationModel
    {
        [Required(ErrorMessage = "Please add Email")]
        [EmailAddress(ErrorMessage ="Invalid Email adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please add Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Please add Email")]
        [EmailAddress(ErrorMessage = "Invalid Email adress")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please add Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


}
