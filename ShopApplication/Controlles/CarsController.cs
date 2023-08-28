using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;
using ShopApplication.ViewModels;

namespace ShopApplication.Controlles
{
    //различные функции, при выхове которых возращается ViewResult
    //ViewResult - специальный тип данных, котоырй возвращает некий объект 
    //в виде HTML страницы
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;
        //устанавливает данные по интерефейсам, через которые мы будем получать все данные
        //за счет того, что в классе Program, выполнили следующие строки:
        //builder.Services.AddTransient<IAllCars, MockCars>();
        //builder.Services.AddTransient<ICarsCategory, MockCategory>();
        //мы связали интерефес и класс и теперь можем обращаться к интерефейсу
        //и по сути мы обращаемся так же к классу, который реализует данный интерефес
        //В итоге, когда мы будет передать сюда какие либо интерфейсы и вместе с нимим
        //будем передавать класс, которые его реализует, а вместе с классом, все 
        //объекты внутри него, в данном случае набор заполненных вручную объектов.
        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _carsCategory = carsCategory;
        }
        //метод, который возвращает целую HTML страницу
        //возвращает список всех товаров
        //при передачи параметра, выводим автомобили
        //которые выходят в категорию параметра (если такая есть)
        //если параметр не передаем, выводим все авто
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Car> cars = null!;
            string carCategory = "";
            if (string.IsNullOrWhiteSpace(category))
            {
                cars = _allCars.Cars.OrderBy(e => e.Id);
            }
            else
            {
                if (category.Equals("electro", StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(e => e.Category.CaregoryName.Equals("Электромобили")).OrderBy(e => e.Id);
                    carCategory = "Электромобили";
                }
                else if (category.Equals("fuel", StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(e => e.Category.CaregoryName.Equals("Классические автомобили")).OrderBy(e => e.Id);
                    carCategory = "Классические автомобили";
                }
                
            }
            ViewBag.Title = "Страница с автомобилями";
            CarListViewModel carListViewModel = new CarListViewModel();
            carListViewModel.AllCars = cars;
            carListViewModel.CurrentCategory = carCategory;
            return View(carListViewModel);
        }
    }
}
