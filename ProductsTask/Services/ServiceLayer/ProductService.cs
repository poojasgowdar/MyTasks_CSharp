using Dtos.Dto;
using Entities.Models;
using Interfaces.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceLayer
{
    public class ProductService : IService
    {
        private readonly IRepository _productRepository;

        public ProductService(IRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
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
                Price = productDto.Price,
                
            };

            _productRepository.Add(product);

            return new ResponseDto
            {
                Message = "Product created successfully.",
                Success = true
            };
        }

       
        public ResponseDto UpdateById(int id,ProductUpdateDto productDto)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = $"Product with ID {id} not found."
                };
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            _productRepository.UpdateById(id, existingProduct);

            return new ResponseDto
            {
                Success = true,
                Message = "Product updated successfully."
            };
        }

        public ResponseDto DeleteById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = $"Product with ID {id} not found."
                };
            }
            _productRepository.DeleteById(id);

            return new ResponseDto
            {
                Success = true,
                Message = "Product deleted successfully."
            };
        }
    }
}
