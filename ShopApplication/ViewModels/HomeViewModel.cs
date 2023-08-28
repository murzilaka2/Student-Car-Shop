using ShopApplication.Data.Models;

namespace ShopApplication.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavoriteCars { get; set; }
    }
}
