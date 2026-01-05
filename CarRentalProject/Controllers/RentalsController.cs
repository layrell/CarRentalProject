using CarRentalProject.Data;
using CarRentalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalProject.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Rent(int carId)
        {
            var rental = new Rental { CarId = carId, ReturnDate = DateTime.Now.AddDays(1) };
            return View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(Rental rental)
        {
            if (rental.ReturnDate <= DateTime.Now)
            {
                ModelState.AddModelError("ReturnDate", "Data zwrotu musi być w przyszłości!");
            }

            if (ModelState.IsValid)
            {
                rental.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                rental.RentDate = DateTime.Now;

                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyRentals");
            }
            return View(rental);
        }

        public IActionResult MyRentals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rentals = _context.Rentals.Where(r => r.UserId == userId).ToList();
            return View(rentals);
        }
    }
}