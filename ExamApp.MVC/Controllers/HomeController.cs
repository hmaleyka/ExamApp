using ExamApp.Business.ViewModels;
using ExamApp.DAL.Context;
using ExamApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM()
            {
                blogs = _context.blogs.ToList(),
            };
            return View(homevm);
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