using CarRentalProject.Data;
using CarRentalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            
                var car = await _context.Cars.FindAsync(rental.CarId);

                if (car != null)
                {
                   
                    var timeSpan = rental.ReturnDate - rental.RentDate;
                    var days = (int)Math.Ceiling(timeSpan.TotalDays); 

                    
                    if (days < 1) days = 1;

             
                    rental.TotalCost = days * car.PricePerDay;
                }

                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyRentals");
            }
            return View(rental);
        }

        public async Task<IActionResult> MyRentals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rentals = await _context.Rentals
                .Include(r => r.Car)
                .Where(r => r.User.UserName == User.Identity.Name) 
                .ToListAsync();
            return View(rentals);
        }
    }
}