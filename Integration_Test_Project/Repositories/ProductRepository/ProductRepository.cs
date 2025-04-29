using DAL.Data;

namespace Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
             return product; 
        }
        public void Update(Product product)
        {
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
    }
}
