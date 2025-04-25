using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductServices
{
    public interface IProductService
    {
        /// <summary>
        /// Fetches all the products
        /// </summary>
        /// <returns></returns>
        List<ProductDTO> GetAllProducts();

        /// <summary>
        /// Fetches an product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetById(int id);

        /// <summary>
        /// Creates an Product
        /// </summary>
        /// <param name="productDto"></param>
        ProductDTO Add(ProductDTO productDto);

        /// <summary>
        /// Updates an Product
        /// </summary>
        /// <param name="productDto"></param>
        bool Update(int id, ProductDTO productDto);

        /// <summary>
        /// Deletes an Product
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
