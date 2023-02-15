using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bekle.Models
{
    public class UserAccount
    {

        public String ID { get; set; }

        [Required(ErrorMessage = "enter your name pls")]
        public String Username { get; set; }

        [Required(ErrorMessage = "enter your surname pls")]
        public String Usersurname { get; set; }

        [Required(ErrorMessage = "Required!")]
        [RegularExpression(@"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$", ErrorMessage = "enter your  valid email pls.")] 
        public String Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "enter your valid password pls. Minimum eight characters, at least one uppercase letter, one lowercase letter and one number:\r\n\r\n")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords not the same check  pls")]
        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        public String confirmpassword { get; set; }


   

    }
}
   