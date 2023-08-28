using ShopApplication.Data.Models;

namespace ShopApplication.Data
{
    public class DbObjects
    {
        //функция для добавления объектов в базу данных
        public static void Initial(AppDbContext appDbContext)
        {
            //проверяем есть ли в таблице хоть какие-то категории
            if (!appDbContext.Categories.Any())
            {
                //если категорий нет, получаем все категории
                appDbContext.Categories.AddRange(Categories.Select(e => e.Value));
            }
            //проверяем есть ли в таблице хоть какие-то автомобили
            if (!appDbContext.Cars.Any())
            {
                //если автомобилей нет, добавляем их
                appDbContext.AddRange
                    (
                    new Car
                    {
                        Name = "Toyota Corolla",
                        ShortDescription = "Car",
                        LongDescription = "Toyota Corolla Car",
                        Image = "https://media.autoweek.nl/m/sa0y7d9b2514_800.jpg",
                        Price = 20_000,
                        IsFavorite = true,
                        Available = 21,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescription = "Car",
                        LongDescription = "Ford Fiesta Car",
                        Image = "https://www.anwb.nl/binaries/content/gallery/anwb/portal/auto/automerken/ford/ford-fiesta-2022/ford-fiesta-front-1.jpg/ford-fiesta-front-1.jpg/anwb%3Aw760",
                        Price = 6_000,
                        IsFavorite = true,
                        Available = 13,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        Name = "Dodge Avenger",
                        ShortDescription = "Car",
                        LongDescription = "Dodge Avenger Car",
                        Image = "https://img.autoabc.lv/Dodge-Avenger/Dodge-Avenger_2007_Sedans_151127121832_9.jpg",
                        Price = 9_000,
                        IsFavorite = true,
                        Available = 7,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        Name = "Audi Q5",
                        ShortDescription = "Car",
                        LongDescription = "Audi Q5E Car",
                        Image = "https://static.moniteurautomobile.be/imgcontrol/images_tmp/clients/moniteur/c680-d465/content/medias/images/news/36000/0/90/audi_sq5_sportback__2_.jpg",
                        Price = 26_300,
                        IsFavorite = true,
                        Available = 12,
                        Category = Categories["Электромобили"]
                    }
                    );
            }
            //сохранение всех изменений в базе данных
            appDbContext.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        //Свойство которое возвращает категории
        //Если категорий нет, создаем новый список со своими категориями
        //Для удобства работы, используем Dictionary
        //Выбирать категорию для авто теперь можем по ее названию
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category { CaregoryName = "Электромобили", Description = "Пиводимый в движение одним или несколькими электродвигателями " +
                    "с питанием от независимого источника электроэнергии"},
                    new Category { CaregoryName = "Классические автомобили", Description = "С двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.CaregoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
