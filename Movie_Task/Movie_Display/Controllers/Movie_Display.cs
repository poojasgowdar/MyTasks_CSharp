using Entities.Context;
using Entities.Models;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie_Display.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movie_Display : ControllerBase
    {
        private readonly IService _productService;

        public Movie_Display(IService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult FilterByName(Movie movie)
        {
           
        }

        [HttpGet]

        public IActionResult FilterByTitle(Movie movie)
        {

        }


       



    }
}
