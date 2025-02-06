using DataAccess.Models;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll(string name, int page, int pageSize);
        public Product GetById(int id);
        public ResponseDto Add(ProductCreateDto productdto);
        public ProductUpdateDto UpdateById(ProductUpdateDto productupdatedto);
        public void DeleteById(int id);
    }
}
