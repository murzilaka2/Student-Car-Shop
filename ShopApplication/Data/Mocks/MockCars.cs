using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Data.Mocks
{
    public class MockCars : IAllCars
    {
        //получаем все категории из класса MockCategory
        private readonly ICarsCategory _carsCategory = new MockCategory();
        List<Car> cars;
        public MockCars()
        {
            cars = new List<Car>()
                {
                    new Car{ Name = "Toyota Corolla", ShortDescription = "Car", LongDescription = "Toyota Corolla Car", Image = "https://media.autoweek.nl/m/sa0y7d9b2514_800.jpg",
                        Price = 20_000, IsFavorite = true, Available = 21, Category = _carsCategory.AllCategories.LastOrDefault()},

                    new Car{ Name = "Ford Fiesta", ShortDescription = "Car", LongDescription = "Ford Fiesta Car",
                        Image = "https://www.anwb.nl/binaries/content/gallery/anwb/portal/auto/automerken/ford/ford-fiesta-2022/ford-fiesta-front-1.jpg/ford-fiesta-front-1.jpg/anwb%3Aw760",
                        Price = 6_000, IsFavorite = true, Available = 13, Category = _carsCategory.AllCategories.LastOrDefault()},

                    new Car{ Name = "Dodge Avenger", ShortDescription = "Car", LongDescription = "Dodge Avenger Car",
                        Image = "https://img.autoabc.lv/Dodge-Avenger/Dodge-Avenger_2007_Sedans_151127121832_9.jpg", Price = 9_000,
                        IsFavorite = true, Available = 7, Category = _carsCategory.AllCategories.LastOrDefault()},

                    new Car{ Name = "Audi Q5", ShortDescription = "Car", LongDescription = "Audi Q5E Car",
                        Image = "https://static.moniteurautomobile.be/imgcontrol/images_tmp/clients/moniteur/c680-d465/content/medias/images/news/36000/0/90/audi_sq5_sportback__2_.jpg",
                        Price = 26_300,IsFavorite = true, Available = 12, Category = _carsCategory.AllCategories.FirstOrDefault()}
                };
        }
        public IEnumerable<Car> Cars
        {
            get
            {
                return cars;
            }
        }
        public IEnumerable<Car> GetFavoriteCars { get; set; }
        public Car GetObjectCar(int carId)
        {
            return cars.Where(e => e.Id == carId).FirstOrDefault()!;
        }
    }
}
