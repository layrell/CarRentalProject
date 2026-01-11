using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentalProject.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public DateTime RentDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Data zwrotu")]
        public DateTime ReturnDate { get; set; }

        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public decimal TotalCost { get; set; } 
    }
}