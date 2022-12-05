using Microsoft.AspNetCore.Mvc;
using PersonalSite.UI.MVC.Models;
using System.Diagnostics;

namespace PersonalSite.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        //Main page Actions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Classmates()
        {
            return View();
        }

        //Contact will go here as well

        //Projects Views

        public IActionResult PortfolioDetails()
        {
            return View();
        }

        public IActionResult APIIntegration()
        {
            return View();
        }

        public IActionResult BiologyPublication()
        {
            return View();
        }

        public IActionResult ReactActivities()
        {
            return View();
        }

        public IActionResult SAT()
        {
            return View();
        }

        public IActionResult StoreFrontApp()
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