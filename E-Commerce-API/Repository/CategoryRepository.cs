using E_Commerce_API.Data;
using E_Commerce_API.Models;
using E_Commerce_API.Repository.IRepository;

namespace E_Commerce_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDBContext applicationDBContext;

        public CategoryRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        
        public bool CategoryExists(int id)
        {
            return applicationDBContext.Categories.Any(c => c.Id == id);
        }

        public bool CategoryExists(string name)
        {
            return applicationDBContext.Categories.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now;
            applicationDBContext.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            applicationDBContext.Categories.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return applicationDBContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int id)
        {
            return applicationDBContext.Categories.FirstOrDefault(c => c.Id == id) ?? throw new InvalidOperationException ($"La categoría con id {id} no existe");
        }

        public bool UpdateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now;
            applicationDBContext.Categories.Update(category);
            return Save();
        }

        public bool Save()
        {
            return applicationDBContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
