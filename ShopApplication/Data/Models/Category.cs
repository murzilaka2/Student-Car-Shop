namespace ShopApplication.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CaregoryName { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }

    }
}
