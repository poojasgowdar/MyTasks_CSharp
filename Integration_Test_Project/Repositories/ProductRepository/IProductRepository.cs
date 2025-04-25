using DAL.Data;

namespace Repositories.ProductRepository
{
    public interface IProductRepository
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
        Product Add(Product product);
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
