using dtos.Dto;
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
         List<ProductDTO> GetProducts();    
         ProductDTO GetById(int id);
         void Add(ProductDTO productDto);
         bool UpdateById(int id, ProductDTO productDto);
         void DeleteById(int id);

    }
}
