using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexaWorks.Data;
using NexaWorks.Models;
using System.Diagnostics;
using NexaWorks.Models.Entities;

namespace NexaWorks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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


        public ActionResult GetItems()
        {
            var items = _context.Tickets
                                .Where(item => item.Description.Contains("example"))
                                .ToList();
            return View(items);
        }

    }
}
