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
         List<Product> GetAllProducts();
         Product GetById(int id);
         void Add(Product product);
         void Update(Product product);
         void Delete(int id);
    }
}
