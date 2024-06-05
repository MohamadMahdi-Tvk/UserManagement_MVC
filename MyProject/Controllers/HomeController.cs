using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Users.Queries;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
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
