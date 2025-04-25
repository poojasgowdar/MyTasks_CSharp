using AutoMapper;
using PlayWrightCrudOperations.DataAccess;
using PlayWrightCrudOperations.DataAccess.Repositories;
using PlayWrightCrudOperations.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightCrudOperations.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
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
