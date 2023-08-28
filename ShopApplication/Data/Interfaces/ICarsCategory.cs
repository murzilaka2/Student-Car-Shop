using ShopApplication.Data.Models;

namespace ShopApplication.Data.Interfaces
{
    //отвечает за получение всех категорий из модели Category
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
