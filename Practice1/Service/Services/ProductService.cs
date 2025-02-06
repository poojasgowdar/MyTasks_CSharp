using Dtos.dto;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService:IService
    {
        private readonly IRepository _productRepository;

        public ProductService(IRepository productRepository)
        {
             _productRepository=  productRepository;
        }
        public Product GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public ResponseDto Add(ProductCreateDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };
            _productRepository.Add(product);
            return new ResponseDto
            {
                Success = true,
                Message = "Product Created Successfully"
            };
        }
        

                   

                
        


    }
}
