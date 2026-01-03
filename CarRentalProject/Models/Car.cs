using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalProject.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka jest wymagana")]
        [StringLength(50, MinimumLength = 2)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model jest wymagany")]
        public string Model { get; set; }

        [Range(1, 1000, ErrorMessage = "Cena musi być dodatnia")]
        [Display(Name = "Cena za dobę (PLN)")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Dostępny")]
        public bool IsAvailable { get; set; } = true;

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public List<Rental>? Rentals { get; set; }
    }
}