using Product_MVC_Project.Interfaces;
using Product_MVC_Project.Models;

namespace Product_MVC_Project.Repositories
{
    public class ProductRepository:IRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public Product GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public bool Update(Product product)
        {
            var products=_context.Products.Update(product);
            _context.SaveChanges();
            return true;
        }
        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
