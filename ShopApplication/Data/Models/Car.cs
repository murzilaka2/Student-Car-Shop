namespace ShopApplication.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
        public int Available { get; set; }
        public Category Category { get; set; }
    }
}
