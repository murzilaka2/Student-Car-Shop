using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Models;

namespace ShopApplication.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //получение всех категорий
        public IEnumerable<Category> AllCategories => appDbContext.Categories; 
    }
}
