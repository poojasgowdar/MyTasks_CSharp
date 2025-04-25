using AutoMapper;
using DataAccessLayer.Entities;
using DTO;
using Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ProductManager
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductDTO> GetAllProducts()
        {
            var product = _productRepository.GetAllProducts();
            return _mapper.Map<List<ProductDTO>>(product);
        }
        public ProductDTO GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public ProductDTO Add(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = _productRepository.Add(product);
            return _mapper.Map<ProductDTO>(createdProduct);
        }
        public bool Update(int id, ProductDTO productDto)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
                return false;

            _mapper.Map(productDto, existingProduct);
            _productRepository.Update(existingProduct);
            return true;
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}

