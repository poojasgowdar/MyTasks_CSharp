using E_Commerce_Application.DataAccessLayer;

namespace E_Commerce_Application.Repository
{
    public interface IRepository<Product> where Product : class
    {
        public IEnumerable<Product> GetAll(string name, int page, int pageSize);
        public Product GetById(int id);
        public void Add(Product product);
        public void UpdateById(Product product);
        public void DeleteById(int id);
        
    }
}
