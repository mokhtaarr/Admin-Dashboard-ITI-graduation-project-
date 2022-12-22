namespace ITI.Ecommerce.Models
{
    public class Category
    {
        public int ID { set; get; }
        public string NameAR { set; get; }
        public string NameEN { set; get; }
        public bool IsDeleted { set; get; }
        public string ImagePath { get; set; }

        //Navigation property
        public virtual ICollection<Product> ProductList { get; set; }

    }
}
