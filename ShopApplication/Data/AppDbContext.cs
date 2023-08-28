using Microsoft.EntityFrameworkCore;
using ShopApplication.Data.Models;

namespace ShopApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Получение всех товаров
        public DbSet<Car> Cars { get; set; }
        //Получение всех категорий
        public DbSet<Category> Categories { get; set; }
        //Товары в корзине
        public DbSet<ShopCarItem> ShopCarItems { get; set; }
        //заказ и информация о заказе
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
