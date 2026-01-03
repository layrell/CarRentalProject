using System.ComponentModel.DataAnnotations;

namespace CarRentalProject.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj swoje imię")]
        public string SenderName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Wiadomość jest za długa")]
        public string Message { get; set; }
    }
}