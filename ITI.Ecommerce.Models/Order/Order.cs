namespace ITI.Ecommerce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
        public int ShoppingCartId { get; set; }


        //Navigation property

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
