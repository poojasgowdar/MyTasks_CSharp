using AutoMapper;
using DTOs.Dto;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProductService : IService
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
            var products = _productRepository.GetAllProducts();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetById(int id)
        {
            var products = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(products);
        }

        public void Add(ProductDTO productDto, List<int> categoryIds)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product, categoryIds);
        }
        public bool Update(int id, ProductDTO productDto)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return false;
            }
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
