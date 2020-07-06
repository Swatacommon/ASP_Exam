using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task23.Models;

namespace Task23.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepository<Phone> phoneRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Phone> rep)
        {
            _logger = logger;
            phoneRepository = rep;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("name"))
            {
                var keys = HttpContext.Session.GetString("name");
                ViewBag.Name = keys;
            }
            else
            {
                HttpContext.Session.SetString("name", "Nikita");

            }
            return View(phoneRepository.GetAllPhones());
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
