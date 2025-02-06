using Dtos.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public ResponseDto Add(ProductCreateDto productdto);

        public ResponseDto UpdateById(int id,ProductUpdateDto productupdatedto);
        public ResponseDto DeleteById(int id);
    }
}





       