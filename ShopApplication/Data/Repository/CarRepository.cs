using Microsoft.EntityFrameworkCore;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContext appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //Получаем все автомобили, включая их категории
        public IEnumerable<Car> Cars => appDbContext.Cars.Include(e => e.Category);
        //Получаем все избранные  автомобили, включая их категории
        public IEnumerable<Car> GetFavoriteCars => appDbContext.Cars.Where(e => e.IsFavorite).Include(e => e.Category);
        //Получаем автомобиль по Id
        public Car GetObjectCar(int carId) => appDbContext.Cars.FirstOrDefault(e=>e.Id == carId);
    }
}
