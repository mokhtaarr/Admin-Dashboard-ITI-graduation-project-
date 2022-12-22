namespace ITI.Ecommerce.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        //public int ProductId { get; set; }
        //public float UnitPrice { get; set; }
        //public int Quantity { get; set; }
        //public float Discount { get; set; }
        //public float Total { get; set; }
        //public string NameAR { set; get; }
        //public string NameEN { set; get; }
        public bool IsDeleted { set; get; }




        //Navigation property
        public virtual ICollection<Product> productList { get; set; }
        public virtual Order Order { get; set; }
    }
}
