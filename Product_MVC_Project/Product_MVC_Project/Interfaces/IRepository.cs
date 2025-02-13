using Product_MVC_Project.Models;

namespace Product_MVC_Project.Interfaces
{
    public interface IRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetById(int id);
        public Product GetByName(string name);
        public void Add(Product product);
        public bool Update(Product product);
        public void Delete(int id);

    }
}
