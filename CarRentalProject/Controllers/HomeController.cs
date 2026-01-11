using CarRentalProject.Data;
using CarRentalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRentalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; 

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
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

     
        public IActionResult Contact()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                message.SentDate = DateTime.Now; 
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();

                ViewData["Message"] = "Dziêkujemy! Twoja wiadomoœæ zosta³a wys³ana.";
                return View();
            }
            return View(message);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}