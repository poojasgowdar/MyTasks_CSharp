using AutoMapper;
using Dto.Dtos;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProductService:IService
    {
        private readonly IRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductDTO> GetAllProducts()
        {
            var products = _productRepository.GetProducts();
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public ProductDTO GetProductById(int id)
        {
            var products = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(products);
        }
        public Product Add(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = _productRepository.Add(product);
            return _mapper.Map<Product>(createdProduct);
        }

        public List<Product> Add(List<ProductDTO> productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = _productRepository.Add(product);
            return _mapper.Map<List<Product>>(createdProduct);
        }
        public bool UpdateById(int id, ProductDTO productDto)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct==null)
            {
                return false;
            }
            _mapper.Map(productDto, existingProduct);
            _productRepository.Update(existingProduct);
             return true;
        }
        public void DeleteById(int id)
        {
            _productRepository.Delete(id);
        }

    }
}
