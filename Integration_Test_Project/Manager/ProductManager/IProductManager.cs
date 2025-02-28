using DTO.DTOs;

namespace Manager.ProductManager
{
    public interface IProductManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ProductDTO> GetAllProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        void Add(ProductDTO productDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        bool Update(int id, ProductDTO productDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
