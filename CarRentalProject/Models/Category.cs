using System.ComponentModel.DataAnnotations;

namespace CarRentalProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [Display(Name = "Kategoria")]
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}