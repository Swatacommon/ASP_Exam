using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Task24.Models;

namespace Task24.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext) // до
        {
            _logger.LogInformation($"BEFORE {filterContext.ActionDescriptor.DisplayName} {filterContext.HttpContext.Request.Method}" +
            $" {filterContext.HttpContext.Request.Path} {filterContext.HttpContext.Request.QueryString}");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext) // после
        {
            _logger.LogInformation($"AFTER {filterContext.ActionDescriptor.DisplayName} {filterContext.HttpContext.Request.Method}" +
          $" {filterContext.HttpContext.Request.Path} {filterContext.HttpContext.Request.QueryString}");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Hello(int id)
        {
            return $"id= {id}";
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
