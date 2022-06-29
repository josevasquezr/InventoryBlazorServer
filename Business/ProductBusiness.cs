using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        public readonly InventoryContext _context;

        public ProductBusiness(InventoryContext context)
        {
            _context = context; 
        }

        public void CreateProduct(ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public ProductEntity GetProductById(Guid id)
        {
            IEnumerable<ProductEntity> products = from product in _context.Products.Include(p => p.Category)
                                                  where product.ProductId == id
                                                  select product;

            return products.FirstOrDefault();
        }

        public List<ProductEntity> ProductList()
        {
            return _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductName)
                .ToList();
        }

        public void UpdateProduct(ProductEntity product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }

    public interface IProductBusiness
    {
        public List<ProductEntity> ProductList();
        public ProductEntity GetProductById(Guid id);
        public void CreateProduct(ProductEntity product);
        public void UpdateProduct(ProductEntity product);
    }
}
