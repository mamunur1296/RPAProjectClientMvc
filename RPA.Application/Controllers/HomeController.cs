using Microsoft.AspNetCore.Mvc;
using RPA.Models;
using System.Diagnostics;

namespace RPA.Application.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
