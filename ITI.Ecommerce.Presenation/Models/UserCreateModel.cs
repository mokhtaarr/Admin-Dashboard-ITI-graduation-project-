using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ITI.Ecommerce.Presenation
{
    public class UserCreateModel
    {
        [Required, MaxLength(400), MinLength(6), Display(Name = "Full Name")]
        public string UserName { get; set; }
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, MaxLength(1000), MinLength(20), Display(Name = "Address")]
        public string Address { get; set; }
        [Required,  DataType(DataType.PhoneNumber), Display(Name = "Mobile Number")
            //,RegularExpression("^01[0125][0 - 9]{8}$")
            ]
        public string MobileNumber { get; set; }

        public string Role { get; set; }

        [Required, MinLength(6), MaxLength(16), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
