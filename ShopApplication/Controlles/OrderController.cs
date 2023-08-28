using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Controlles
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        //В этот метод переходим при первом заходе на страницу Checkout
        public IActionResult Checkout()
        {
            return View();
        }
        //За счет атрибуита HttpPostб этот метод переходим при отправке Post запроса,
        //который отправляет форма при нажатии на кнопку с типом Submit.
        //Данный метод принимает заказ, который передается из формы - @model Order
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ShopCarItems = shopCart.GetShopItems();
            if (shopCart.ShopCarItems.Count == 0)
            {
                //ModelState позволяет выдать пользователю ошибку
                ModelState.AddModelError("","Пустая корзина");
            }
            //Вернет true, если все свойства(поля) описанный в модели
            //проходят проверку
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                //переадресовуем пользователя на другое представление
                return RedirectToAction("Complete");
            }
            //Если данные заполнены не верно, происходит перезагрузка страницы
            //Передаем на страницу объект order, ранее заполненный, что бы данные
            //подставились
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
