using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public  interface IRepository<T> where T:class
    {
       /// <summary>
       /// Get all items
       /// </summary>
       /// <returns></returns>
        public IEnumerable<T> All();

        //get item by Id
        public T GetSingle(Expression<Func<T, bool>> predicate);
        public T GetSingleOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
    }
}
