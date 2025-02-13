using AutoMapper;
using Product_MVC_Project.dtos;
using Product_MVC_Project.Interfaces;
using Product_MVC_Project.Models;

namespace Product_MVC_Project.Services
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
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public ProductDTO GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public bool Add(ProductDTO productDto, out string errorMessage)
        {
            errorMessage = string.Empty;
            var existingProduct = _productRepository.GetByName(productDto.Name);
            if (existingProduct != null)
            {
                errorMessage = "Product name already exists!";
                return false;
            }

            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
            return true;
        }
        public bool UpdateById(int id, ProductDTO productDto)
        {
            var existingProduct = _productRepository.GetById(id);
           _mapper.Map(productDto, existingProduct);
            return _productRepository.Update(existingProduct);
        }
        public void DeleteById(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
