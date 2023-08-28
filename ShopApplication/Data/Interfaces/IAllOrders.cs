using ShopApplication.Data.Models;

namespace ShopApplication.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
