using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.Models.ViewModels
{
    public class OrderCreateVM
    {
        [Required]
        [Display(Name = "Klient")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Produkt")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 100000)]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        public List<SelectListItem> Customers { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();
    }
}
