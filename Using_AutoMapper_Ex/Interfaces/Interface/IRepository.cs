using dtos.dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IRepository
    {
        public List<Product> GetAllProducts(string name,int page,int pageSize);
        public Product GetById(int id);
        public void Add(Product product);
        public void AddBulk(List<Product> products);
        public void Update(Product product);
        public void Delete(int id);
        public bool DeleteBulk(List<int> productIds);


    }
}
