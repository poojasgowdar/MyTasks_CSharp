using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ProductRepository:IRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
             return _context.Products.Include(p => p.ProductCategories)
                                     .ThenInclude(pc => pc.Category)
                                     .AsNoTracking()
                                     .ToList();
        }
       
        public Product GetById(int id)
        {
            return _context.Products.Include(p => p.ProductCategories)
                                 .ThenInclude(pc => pc.Category)
                                 .FirstOrDefault(p => p.ProductId == id);
        }

        public void Add(Product product, List<int> categoryIds)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            if (categoryIds != null && categoryIds.Count > 0)
            {
                foreach (var categoryId in categoryIds)
                {
                    _context.ProductCategories.Add(new ProductCategory
                    {
                        ProductId = product.ProductId,
                        CategoryId = categoryId
                    });
                }
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var student = _context.Products.Find(id);
            if (student != null)
            {
                _context.Products.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
