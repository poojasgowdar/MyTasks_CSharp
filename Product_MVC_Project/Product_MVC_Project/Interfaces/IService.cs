using Product_MVC_Project.dtos;
using Product_MVC_Project.Models;

namespace Product_MVC_Project.Interfaces
{
    public interface IService
    {
        public IEnumerable<Product> GetProducts();
        public ProductDTO GetById(int id);
        public bool Add(ProductDTO productDto, out string errorMessage);
        public bool UpdateById(int id, ProductDTO productDto);
        public void DeleteById(int id);
    }
}
