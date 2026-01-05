using CarRentalProject.Data;
using CarRentalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();
                ViewBag.Success = "Wiadomoœæ wys³ana!";
                return View();
            }
            return View(message);
        }
    }
}