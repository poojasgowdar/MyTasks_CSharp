using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC_New_Project.Interfaces;
using MVC_New_Project.Models;
using System.Reflection.Metadata.Ecma335;

namespace MVC_New_Project.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            HttpContext.Session.SetString("ProductCount", products.Count().ToString());
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(5),
                HttpOnly = true
            };
            Response.Cookies.Append("ProductCount", products.Count().ToString(), cookieOptions);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                HttpContext.Session.SetString("ProductName", product.Name);
                CookieOptions cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(5),
                    HttpOnly = true
                };
                Response.Cookies.Append("ProductName", product.Name, cookieOptions);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();  
            }
            if (ModelState.IsValid)
            {
                _productRepository.UpdateById(id,product);
                HttpContext.Session.SetString("UpdatedProductName", product.Name);
                CookieOptions cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(1),
                    HttpOnly = true
                };
                Response.Cookies.Append("UpdatedProductName", product.Name, cookieOptions);
                return RedirectToAction(nameof(Index));  
            }
            return View(product);  
        }
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.DeleteById(id);
            HttpContext.Session.SetString("DeletedProductName",DateTime.UtcNow.ToString());
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(1),
                HttpOnly = true
            };
            Response.Cookies.Append("ProductDeleteStatus", "Product deleted successfully!", cookieOptions);
            return RedirectToAction(nameof(Index));
        
        }


    }
}
