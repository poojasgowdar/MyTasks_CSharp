using AutoMapper;
using Dtos.Dto;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public List<Product> GetAllProducts(string name,int page,int pageSize)
        {
            return _productRepository.GetProducts(name, page, pageSize);
        }
        public ProductDTO GetProductsById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public void Add(ProductDTO productDto)
        {   
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
        }
        public void AddBulk(List<ProductDTO> productDtos)
        {
            var products = _mapper.Map<List<Product>>(productDtos);
            _productRepository.AddBulk(products);
        }
        public bool  UpdateById(int id, ProductDTO productDto)
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
        public void DeleteById(int id)
        {
            _productRepository.Delete(id);
        }
        public bool DeleteBulk(List<int> productDtos)
        {
            return _productRepository.DeleteBulk(productDtos);
        }
    }
}
