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
            using (_context)
            {
                return _context.Categories.ToList();
            }
        }

        public void CreateCategory(CategoryEntity category)
        {
            using (_context)
            {
                _context.Add(category);
                _context.SaveChanges();
            }
        }

        public CategoryEntity GetCategoryById(Guid id)
        {
            using (_context)
            {
                IEnumerable<CategoryEntity> categories = from cat in _context.Categories
                                                         where cat.CategoryId == id
                                                         select cat;

                return categories.FirstOrDefault();
            }
        }

        public void UpdateCategory(CategoryEntity category)
        {
            using (_context)
            {
                _context.Update(category);
                _context.SaveChanges();
            }
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
