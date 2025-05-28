namespace SmartStocker.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime DateOrdered { get; set; }

        public int OrderedById { get; set; }
        public User OrderedBy { get; set; }
    }
}
