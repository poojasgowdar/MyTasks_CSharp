using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly BookDbContext _context;
        public BaseRepository(BookDbContext context)
        {
            _context = context;
        }
       

        public IEnumerable<T> All()
        {
            return _context.Set<T>().ToList();
        }
        public T GetSingle(Expression<Func<T,bool>>predicate)
        {
            return _context.Set<T>().First(predicate);
        }

        public T GetSingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public void Add(T entity)
        {
            _context.Add<T>(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update<T>(entity);
            _context.SaveChanges();
        }
    }
}
