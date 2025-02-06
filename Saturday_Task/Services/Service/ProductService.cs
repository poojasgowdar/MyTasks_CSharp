using Dtos.Dto;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
        private readonly IRepository<Product> _productRepository;
        private readonly AppDbContext _context;

        public ProductService(IRepository<Product> productRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public ProductDto Add(Product product, List<int> categoryIds)
        {
            if (categoryIds == null || categoryIds.Count == 0)
                throw new ArgumentException("CategoryIds are required.");
      
            var validCategoryIds = _context.Categories.Select(c => c.Id).ToList();
            var invalidCategoryIds = categoryIds.Except(validCategoryIds).ToList();

            if (invalidCategoryIds.Any())
            {
                throw new ArgumentException($"Invalid CategoryIds: {string.Join(", ", invalidCategoryIds)}.");
            }

            var categories = _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToList();

            product.ProductCategories = categories.Select(c => new ProductCategory
            {
                ProductId = product.Id, 
                CategoryId = c.Id
            }).ToList();

         
            _productRepository.Add(product);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductCategories = product.ProductCategories.Select(pc => new CategoryDto
                {
                    CategoryId = pc.CategoryId,
                    CategoryName = pc.Category.Name 
                }).ToList()
            };
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductCategories = product.ProductCategories.Select(pc => new CategoryDto
                {
                    CategoryId = pc.CategoryId,
                    CategoryName = pc.Category.Name
                }).ToList()
            };
        }

         public string UpdateProductById(int id, ProductCreate product)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return $"Product with Id {id} not found.";
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            _productRepository.UpdateById(id, existingProduct);

            return $"Product with Id {id} updated successfully.";
        }

        public string DeleteProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if(product==null)
            {
                return $"Product with Id {id} does not exist.";
            }
            _productRepository.DeleteById(id);
            return $"Product Deleted Successfully";

        }

    }




}

