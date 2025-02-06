using AutoMapper;
using dtos.Dto;
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

        public List<ProductDTO> GetProducts()
        {
            var product = _productRepository.GetAllProducts();
            return _mapper.Map<List<ProductDTO>>(product);
        }

        public ProductDTO GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }
        
        public void Add(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
        }

        public bool UpdateById(int id, ProductDTO productDto)
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
    }
}
