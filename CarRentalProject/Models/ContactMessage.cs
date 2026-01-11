using System.ComponentModel.DataAnnotations;

namespace CarRentalProject.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj swoje imię")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wpisz treść wiadomości")]
        [StringLength(500, ErrorMessage = "Wiadomość jest za długa")]
        public string Message { get; set; }

        public DateTime SentDate { get; set; } 
    }
}