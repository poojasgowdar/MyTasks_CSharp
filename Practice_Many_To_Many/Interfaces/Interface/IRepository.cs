using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="categoryIds"></param>
        void Add(Product product, List<int> categoryIds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        
    }
}
