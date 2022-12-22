using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ITI.Ecommerce.Presenation.Models
{
    public class CategoryModel
    {
        [Display(Name = "Name Arabic")]
        public string NameAR { get; set; }
        [Display(Name = "Name English")]
        public string NameEN { get; set; }
    }
}
