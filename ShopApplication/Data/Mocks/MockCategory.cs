using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Data.Mocks
{
    //Вместо базы данных, храним данные в виде текста
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CaregoryName = "Электромобили", Description = "Пиводимый в движение одним или несколькими электродвигателями " +
                    "с питанием от независимого источника электроэнергии"},
                    new Category { CaregoryName = "Классические автомобили", Description = "С двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
