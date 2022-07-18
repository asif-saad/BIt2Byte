using Bit2Byte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bit2Byte.Controllers
{
    public class HomeController : Controller
    {

        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }


        [ViewData]
        public BookModel Book { get; set; }

        private readonly ILogger<HomeController> _logger;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HomeController(ILogger<HomeController> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Title = "Home page from controller";
            CustomProperty = "Custom value";
            ViewData["property1"] = "Asif Saad";

            Book = new BookModel() { Id = 1, Title = "it is a test" };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Events()
        {
            return View();
        }


        public IActionResult About()
        {
            Title = "About Us";
            return View();
        }

        public IActionResult Achievements()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}