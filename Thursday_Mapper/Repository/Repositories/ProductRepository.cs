﻿using Dto.Dtos;
using Interfaces.Interface;
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
            //return _context.Products.FirstOrDefault(p=>p.Id==id);
        }
        public Product Add(Product product)
        {
             _context.Products.Add(product);
             _context.SaveChanges();
             return product;
        }
        public List<Product> AddBulk(List<Product> products)
        {
            _context.AddRange(products);
            _context.SaveChanges();
            return products;
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
