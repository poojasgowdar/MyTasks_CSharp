using DTOs.Dto;
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
        /// 
        /// </summary>
        /// <returns></returns>
        List<ProductDTO> GetAllProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></retGetByIdurns>
        ProductDTO GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        void Add(ProductDTO productDto, List<int> categoryIds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        bool Update(int id,ProductDTO productDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
