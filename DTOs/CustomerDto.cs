using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    // add CustomerDto property
    public class CustomerDto :IdentityUser
    {
        public string ID { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "MobileNumber")]
        public string MobileNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string NameAR { set; get; }
        public string NameEN { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime DateEntered { get; set; }

        public ICollection<OrderDto> orderList { get; set; }
    }
}
