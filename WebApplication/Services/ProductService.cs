using DataAccess.Models;
using Interfaces;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll(string name, int page, int pageSize)
        {
            // Calls the repository to fetch products with pagination and filtering
            return _productRepository.GetAll(name, page, pageSize);
        }

        public Product GetById(int id)
        {
            // Fetch a product by ID
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            return product;
        }

        public ResponseDto Add(ProductCreateDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity
            };

            _productRepository.Add(product);

            return new ResponseDto
            {
                Message = "Product created successfully.",
                Success = true
            };
        }

        public ProductUpdateDto UpdateById(ProductUpdateDto productDto)
        {
            var existingProduct = _productRepository.GetById(productDto.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {productDto.Id} not found.");

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.StockQuantity = productDto.StockQuantity;

            _productRepository.UpdateById(existingProduct);

            return productDto;
        }


        public void DeleteById(int id)
        {
            // Check if the product exists
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            // Delete product
            _productRepository.DeleteById(id);
        }

    }
}
