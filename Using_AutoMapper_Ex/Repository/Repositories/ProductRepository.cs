using Interfaces.Interface;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository:IRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts(string name, int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void AddBulk(List<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

        }
        public bool DeleteBulk(List<int> productIds)
        {
            var products = _context.Products.Where(p => productIds.Contains(p.Id)).ToList();
            if (!products.Any())
            {
                return false;
            }
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
            return true;
        }
    }
}
