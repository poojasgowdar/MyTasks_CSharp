using Dto.Dtos;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Moq;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest_Cases
{
    public class UserRepositoryTest
    {
        private readonly Mock<IRepository> _mockRepository;

        public UserRepositoryTest()
        {
            _mockRepository = new Mock<IRepository>();
        }
        
        [Fact]
        public void GetProducts()
        {
            var mockProducts = new List<Product>
            {
            new Product { Id = 1, Name = "Laptop" },
            new Product { Id = 2, Name = "Phone" },
            new Product { Id = 3, Name = "Tablet" } 
            };
            _mockRepository.Setup(repo => repo.GetProducts()).Returns(mockProducts);

            var products = _mockRepository.Object.GetProducts();
            Assert.NotNull(products);
            Assert.Equal(3, products.Count());
        }

        [Fact]
        public void GetProductById_ReturnsCorrectProduct()
        {
 
            var mockRepository = new Mock<IRepository>();
            var mockProduct = new Product { Id = 1, Name = "Laptop" };

            mockRepository.Setup(repo => repo.GetById(1)).Returns(mockProduct);
            var result = mockRepository.Object.GetById(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id); 
            Assert.Equal("Laptop", result.Name);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

       


    }
}
