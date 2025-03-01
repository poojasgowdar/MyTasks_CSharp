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
        public List<Product> GetProducts();
        public Product GetById(int id);
        public void Add(Product product);
        public void Update(Product Product);
        public void Delete(int id);
    }
}
