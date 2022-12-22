namespace ITI.Ecommerce.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool IsAllowed { get; set; }

        //Navigation property
        public virtual Order Order { get; set; }

    }
}
