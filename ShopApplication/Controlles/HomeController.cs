using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;
using ShopApplication.ViewModels;

namespace ShopApplication.Controlles
{
    public class HomeController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;
        public HomeController(IAllCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }
        //Вывод только избраных товаров
        public ViewResult Index()
        {
            ViewBag.Title = "Автомагазин";
            var homeCars = new HomeViewModel
            {
                FavoriteCars = carRepository.GetFavoriteCars
            };
            return View(homeCars);
        }
    }
}
