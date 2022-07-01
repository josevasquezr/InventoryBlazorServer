using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly InventoryContext _context;
        public CategoryBusiness(InventoryContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> CategoryList()
        {
            return _context.Categories.OrderBy(p => p.CategoryName).ToList();
        }

        public void CreateCategory(CategoryEntity category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public CategoryEntity GetCategoryById(Guid id)
        {
            IEnumerable<CategoryEntity> categories = from cat in _context.Categories
                                                     where cat.CategoryId == id
                                                     select cat;

            return categories.FirstOrDefault();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }

    public interface ICategoryBusiness
    {
        public List<CategoryEntity> CategoryList();
        public CategoryEntity GetCategoryById(Guid id);
        public void CreateCategory(CategoryEntity category);
        public void UpdateCategory(CategoryEntity category);
    }
}
