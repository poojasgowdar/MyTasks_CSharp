using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
