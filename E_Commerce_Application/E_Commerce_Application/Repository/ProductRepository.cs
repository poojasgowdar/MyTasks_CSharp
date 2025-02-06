using E_Commerce_Application.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace E_Commerce_Application.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll(string name, int page, int pageSize)
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
        public void UpdateById(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var product =  _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChangesAsync();
            }
        }
        
    }
}
