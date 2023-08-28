using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDbContext appDbContext, ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            //создание заказа
            order.OrderTime = DateTime.Now;
            appDbContext.Orders.Add(order);
            appDbContext.SaveChanges();
            //получение всех товаров из корзинкы пользователя
            var items = shopCart.ShopCarItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id
                };
                appDbContext.OrderDetails.Add(orderDetail);
            }
            appDbContext.SaveChanges();
        }
    }
}
