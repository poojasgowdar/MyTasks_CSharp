using Dto.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
        /// <summary>
        /// Lists all the Products
        /// </summary>
        /// <returns></returns>
        List<ProductDTO> GetAllProducts();

        /// <summary>
        /// Fetches an Product By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetProductById(int id);
        /// <summary>
        /// Creates an New Product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        /// 
        Product Add(ProductDTO productDto);

        /// <summary>
        /// Creates an Bulk Products
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        List<ProductDTO> AddBulk(List<ProductDTO> productDto);

        /// <summary>
        /// Updates an Existing Product by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        bool UpdateById(int id, ProductDTO productDto);
        /// <summary>
        /// Deletes an Product by ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
