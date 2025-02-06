using Dtos.Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
        public ProductDto Add(Product product, List<int> categoryIds);
        public ProductDto GetProductById(int id);

        public string UpdateProductById(int id, ProductCreate product);

        public string DeleteProductById(int id);
    }
}
