using Microsoft.EntityFrameworkCore;

namespace ShopApplication.Data.Models
{
    //Класс, который представляет корзину
    public class ShopCart
    {
        //Объект, необходимы для работы с базой данных
        private readonly AppDbContext appDbContext;
        public ShopCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCarItem> ShopCarItems { get; set; }
        public static ShopCart GetCart(IServiceProvider service)
        {
            //объект, с помощью которого, мы сможем работать с сессией
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = service.GetService<AppDbContext>();
            //получаем Id корзины пользователя из сессии, если значения нет, создаем новый идентификатор
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //устаналиваем ID как сессию, если такого ID не было, создается новая сессия
            //если есть, то ничгео не меняется
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        //добавление товаров в корзину
        public void AddToCart(Car car)
        {
            appDbContext.ShopCarItems.Add(new ShopCarItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });
            appDbContext.SaveChanges();
        }
        //отображение всех товаров из корзины, у которых ID корзины, равен ID корзины полученного из сессии
        public List<ShopCarItem> GetShopItems() => appDbContext.ShopCarItems.Where(e => e.ShopCartId == ShopCartId).Include(e=>e.Car).ToList();
    }
}
