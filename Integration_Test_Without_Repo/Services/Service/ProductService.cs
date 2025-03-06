using AutoMapper;
using DTOs.Dto;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public ProductDTO GetProductById(int id)
        {
            var products = _context.Products.Find(id);
            return _mapper.Map<ProductDTO>(products);
        }

        public ProductDTO AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return _mapper.Map<ProductDTO>(product);
        }

        public bool UpdateProduct(int id, ProductDTO productDto)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id); 
            if (existingProduct != null)
            {
                _mapper.Map(productDto, existingProduct);
                _context.Update(existingProduct);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void DeleteById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }


    }
}
