namespace ITI.Ecommerce.Models
{
    public class ProductImage
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public int ProductID { get; set; }
        public bool IsDeleted { get; set; }

        //Navigation property
        public virtual Product Product { get; set; }

    }
}
