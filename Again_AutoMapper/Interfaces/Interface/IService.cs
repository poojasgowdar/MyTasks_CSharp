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
        public List<ProductDTO> GetProducts();
        public ProductDTO GetById(int id);
        public void Add(ProductDTO productDto);
        public bool UpdateById(int id, ProductDTO productDto);
        public void DeleteById(int id);

    }
}
