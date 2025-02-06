using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IRepository<T> where T:class
    {
        public void Add(T entity);
        public T GetById(int id);

        public void UpdateById(int id, T entity);
        public void DeleteById(int Id);
    }
}



