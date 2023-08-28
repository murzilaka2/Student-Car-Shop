using ShopApplication.Data.Models;

namespace ShopApplication.Data.Interfaces
{
    public interface IAllCars
    {
        //получаем и устанавливаем все авто
        IEnumerable<Car> Cars { get; }
        //получаем и устанавливаем избраные авто
        IEnumerable<Car> GetFavoriteCars { get; }
        //получение определенного авто
        Car GetObjectCar(int carId);
    }
}
