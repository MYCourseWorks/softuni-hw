namespace CarDealer.Data.Model
{
    public class Sale
    {
        public int Id { get;  set; }

        public decimal Discount { get; set; }

        public Customer Customer { get; set; }

        public Car Car { get; set; }
    }
}
