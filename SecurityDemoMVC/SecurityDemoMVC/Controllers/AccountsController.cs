using Microsoft.AspNetCore.Mvc;

namespace SecurityDemoMVC.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
