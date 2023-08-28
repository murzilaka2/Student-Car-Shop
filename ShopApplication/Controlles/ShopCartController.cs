using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;
using ShopApplication.ViewModels;

namespace ShopApplication.Controlles
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }
        //отображение коризны
        public ViewResult Index()
        {
            //получение всех товаров из корзины
            var items = shopCart.GetShopItems();
            shopCart.ShopCarItems = items;
            //создали ViewModel, для передачи нескольких значений в представление
            var obj = new ShopCartViewModel
            {
                ShopCart = shopCart
            };
            return View(obj);
        }
        //добавление товара в корзину (по его Id) и переадресация на другую страницу
        public RedirectToActionResult AddToCart(int id)
        {
            var item = carRepository.Cars.FirstOrDefault(e=>e.Id == id);
            if (item != null)
            {
                shopCart.AddToCart(item);
            }
            //когда нажмем на добавление товара, переадресуем пользователя на страницу с корзиной
            return RedirectToAction("Index");
        }

    }
}
