namespace ShopApplication.Data.Models
{
    //Описывает каждый товар внутри корзины
    public class ShopCarItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public decimal Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
