using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
   public class CategoryDto
    {
        public int ID { set; get; }
        [Display(Name = "Name Arabic")]
        public string NameAR { set; get; }
        [Display(Name = "Name English")]
        public string NameEN { set; get; }
        public bool IsDeleted { set; get; }

        public ICollection<ProductDto> ProductList { get; set; }
    }
}
