using System.ComponentModel.DataAnnotations;


namespace ITI.Ecommerce.Presenation

{
    public class ProductModel
    {
        public int ID { get; set; }
        [Display(Name = "Name Arabic")]

        [Required(ErrorMessage = "Required")]

        [MaxLength(500, ErrorMessage = "Must be At Most 500 Chars")]
        [MinLength(4, ErrorMessage = "Must be At least 4 Chars")]
        public string NameAR { get; set; }
        [Display(Name = "Name English")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(500, ErrorMessage = "Must be At Most 500 Chars")]
        [MinLength(4, ErrorMessage = "Must be At least 4 Chars")]
        public string NameEN { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(500, ErrorMessage = "Must be At Most 500 Chars")]
        public string Brand { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(5000, ErrorMessage = "Must be At Most 5000 Chars")]

        public string Description { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Not valid Number")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Not valid Number")]
        [Display(Name = "UnitPrice")]
        public float UnitPrice { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Not valid Number")]
        [Display(Name = "Discount")]
        public float Discount { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Not valid Number")]
        [Display(Name = "TotalPrice")]
        public float TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        /// public ICollection<Microsoft.AspNetCore.Http.IFormFile> Images { get; set; }
        [Display(Name = "Images")]
        public List<IFormFile> Images { get; set; }

    }
}
