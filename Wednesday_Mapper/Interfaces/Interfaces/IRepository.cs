using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IRepository
    {
        public List<Product> GetProducts(string name,int page,int pageSize);
        public Product GetById(int id);
        public void Add(Product product);
        public void AddBulk(List<Product> product);
        public void Update(Product product);
        public void Delete(int id);
        public bool DeleteBulk(List<int> productIds);
    }
}
