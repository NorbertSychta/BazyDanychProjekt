using System.ComponentModel.DataAnnotations;

namespace Projekt.Models;

public class Customer
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string State { get; set; } = string.Empty; // np. "CA", "NY"

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
