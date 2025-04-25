using Dtos.Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Fetches an all the Products
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<Product> GetAllProducts(string name,int page,int pageSize);

        /// <summary>
        /// Fetches an Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetProductsById(int id);

        /// <summary>
        /// Creates an new Product
        /// </summary>
        /// <param name="productDto"></param>
        void Add(ProductDTO productDto);

        /// <summary>
        /// Creates an Bulk Product
        /// </summary>
        /// <param name="productDtos"></param>
        void AddBulk(List<ProductDTO> productDtos);

        /// <summary>
        /// Updates an Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        bool UpdateById(int id, ProductDTO productDto);

        /// <summary>
        /// Deletes an Product By Id
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);

        /// <summary>
        /// Deletes an Bulk Product
        /// </summary>
        /// <param name="productDtos"></param>
        /// <returns></returns>
        bool DeleteBulk(List<int> productDtos);
    }
}
