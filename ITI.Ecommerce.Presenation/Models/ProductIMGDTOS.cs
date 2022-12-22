using System.ComponentModel.DataAnnotations;
namespace ITI.Ecommerce.Presenation


{
    public class ProductIMGDTOS
    {
        public int ID { get; set; }
        [Display(Name = "Choice Images")]
        public IFormFile Path { get; set; }
    [Display(Name = "Product")]
    public int ProductID { get; set; }
    }
}
