using DataAccessLayer.Models;
using Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
        public IEnumerable<Product> GetAll(string name, int page, int pageSize);
        public Product GetById(int id);
        public ResponseDto Add(ProductCreateDto productdto);
        public ResponseDto AddBulk(List<ProductCreateDto> productDtos);
        public ProductUpdateDto UpdateById(ProductUpdateDto productupdatedto);
        public void DeleteById(int id);
    }
}
