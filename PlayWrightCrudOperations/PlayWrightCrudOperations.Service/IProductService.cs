using PlayWrightCrudOperations.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightCrudOperations.Service
{
    public interface IProductService
    {
        /// <summary>
        /// Fetches all the products
        /// </summary>
        /// <returns></returns>
        List<ProductDTO> GetProducts();
        /// <summary>
        /// Fetch a particular product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetById(int id);
        /// <summary>
        /// Creates an new Product
        /// </summary>
        /// <param name="productDto"></param>
        void Add(ProductDTO productDto);
        /// <summary>
        /// Updates an particular product by Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        bool UpdateById(int id, ProductDTO productDto);
        /// <summary>
        /// Deletes an Product
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
