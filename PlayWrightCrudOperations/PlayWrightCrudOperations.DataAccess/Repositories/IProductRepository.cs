using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightCrudOperations.DataAccess.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Fetches all the products
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();
        /// <summary>
        /// Fetch a particular product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetById(int id);
        /// <summary>
        /// Creates an new Product
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);
        /// <summary>
        /// Updates an particular product by Id
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);
        /// <summary>
        /// Deletes an Product
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
