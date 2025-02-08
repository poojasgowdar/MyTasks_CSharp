using Interfaces.Interface;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository:IRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product Product)
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var products = _context.Products.Find(id);
            if (products != null)
            {
                _context.Products.Remove(products);
                _context.SaveChanges();
            }
        }
    }
}
