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
        public List<Product> GetAllProducts();
        public Product GetById(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);


    }
}
