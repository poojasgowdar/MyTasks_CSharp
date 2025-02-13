using Microsoft.AspNetCore.Mvc;
using Product_MVC_Project.dtos;
using Product_MVC_Project.Interfaces;
using Product_MVC_Project.Models;
using Product_MVC_Project.Repositories;

namespace Product_MVC_Project.Controllers
{    
    public class ProductController : Controller
    {
        private readonly IService _productService;
        public ProductController(IService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductDTO productDto)
        {
            string errorMessage;
            bool isAdded = _productService.Add(productDto, out errorMessage);

            if (!isAdded)
            {
                ViewBag.ErrorMessage = errorMessage;
                return View(productDto);
            }

            TempData["SuccessMessage"] = "Product added successfully!";
            return RedirectToAction("Index"); 
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(int id, ProductDTO productDto)
        {
            var result = _productService.UpdateById(id, productDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteProduct()
        {
           return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

