using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class ProductImageDto
    {
        public int ID { get; set; }
        [Display(Name = "Choice Images")]
        public  string Path { get; set; }
        [Display(Name = "Product")]
        public int ProductID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
