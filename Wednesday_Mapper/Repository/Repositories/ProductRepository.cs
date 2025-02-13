using Interfaces.Interfaces;
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
        public List<Product> GetProducts(string name, int page, int pageSize)
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
            _context.Add(product);
            _context.SaveChanges();
        }

        public void AddBulk(List<Product> product)
        {
            _context.AddRange(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var products = _context.Products.Find(id);
            if (products != null)
            {
                _context.Products.Remove(products);
                _context.SaveChanges();
            }
        }
        public bool DeleteBulk(List<int> productIds)
        {
            var products = _context.Products.Where(p => productIds.Contains(p.Id)).ToList();
            if (products.Count != productIds.Count)
            {
                return false;
            }
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
            return true;
        }
    }
}
