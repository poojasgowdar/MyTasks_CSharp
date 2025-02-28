using DTO.DTOs;
using Manager.ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductManager _productManager;
        public ProductService(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public List<ProductDTO> GetAllProducts()
        {
            return _productManager.GetAllProducts();
        }

        public ProductDTO GetById(int id)
        {
            return _productManager.GetById(id);
        }

        public void Add(ProductDTO productDto)
        {
            _productManager.Add(productDto);
        }
        public bool Update(int id, ProductDTO productDto)
        {
            return _productManager.Update(id, productDto);
        }
        public void Delete(int id)
        {
            _productManager.Delete(id);
        }
    }

}
