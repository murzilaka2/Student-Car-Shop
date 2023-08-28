namespace ShopApplication.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public Order Order { get; set; }
    }
}
