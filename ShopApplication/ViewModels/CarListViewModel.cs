using ShopApplication.Data.Models;

namespace ShopApplication.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
