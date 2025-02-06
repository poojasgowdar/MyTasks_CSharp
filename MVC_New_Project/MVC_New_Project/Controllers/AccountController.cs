using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_New_Project.Models;

namespace MVC_New_Project.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", "Invalid credentials.Please try again...");
            return View();
        }
       
    }
}
