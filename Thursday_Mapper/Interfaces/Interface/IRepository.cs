using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IRepository
    {
        /// <summary>
        /// Lists All the Products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();

        /// <summary>
        /// Fetches an product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetById(int id);

        /// <summary>
        /// Creates an New Product
        /// </summary>
        /// <param name="product"></param>
        Product Add(Product product);

        /// <summary>
        /// Creates an Bulk Products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        List<Product> AddBulk(List<Product> products);

        /// <summary>
        /// Updates an Product 
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Deletes an Product By Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
