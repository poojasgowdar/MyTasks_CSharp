using DataAccess;
using DataAccess.Models;
using Interface.Interfaces;
using Service;


namespace ManagementAPI.Repositories
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
        public void AddBulk(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
        public void UpdateById(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public void DeleteBulkProducts(IEnumerable<int> productIds)
        {
            var productsToRemove = _context.Products.Where(p => productIds.Contains(p.Id)).ToList();
            if (productsToRemove.Any())
            {
                // Remove the products from the database
                _context.Products.RemoveRange(productsToRemove);
                _context.SaveChanges(); // Commit the changes to the database
            }
            else
            {
                throw new Exception("No products found with the provided IDs.");
            }
        }
    }
}

        
    

