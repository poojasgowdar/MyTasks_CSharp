using Dtos.Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IService
    {
        public List<Product> GetAllProducts(string name,int page,int pageSize);
        public ProductDTO GetProductsById(int id);
        public void Add(ProductDTO productDto);
        public void AddBulk(List<ProductDTO> productDtos);
        public bool UpdateById(int id, ProductDTO productDto);
        public void DeleteById(int id);
        public bool DeleteBulk(List<int> productDtos);
    }
}
