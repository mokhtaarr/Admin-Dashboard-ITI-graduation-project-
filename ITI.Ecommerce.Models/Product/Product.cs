namespace ITI.Ecommerce.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        //Navigation property
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> productImageList { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCartList { get; set; }
    }
}
