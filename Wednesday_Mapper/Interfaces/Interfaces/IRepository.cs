using Models.Entities;

namespace Interfaces.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// Fetches all the Products
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<Product> GetProducts(string name, int page, int pageSize);

        /// <summary>
        /// Fetches an Product by Id
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
        /// Creates an Bulk Products
        /// </summary>
        /// <param name="product"></param>
        void AddBulk(List<Product> product);

        /// <summary>
        /// Updates an Existing Product
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Deletes an Product
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Deletes an Bulk Product
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        bool DeleteBulk(List<int> productIds);
    }
}