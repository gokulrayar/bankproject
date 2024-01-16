using dockerproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dockerproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<Users> userlist = new List<Users>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;


            userlist.Add(new Models.Users { Username = "rayar", Password = "rayar@773" });
            userlist.Add(new Models.Users { Username = "Luffy", Password = "luffy@123" });
            userlist.Add(new Models.Users { Username = "Zoro", Password = "lost@123" });
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Users u)
        {
            var found = userlist.Find(f => ((f.Username == u.Username) && (f.Password == u.Password)));

            if (found != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            else
            {
                return View();
            }
        }
        public IActionResult Dashboard()
        {

            return View();
        }

        public IActionResult Privacy()
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


