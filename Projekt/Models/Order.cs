using System.ComponentModel.DataAnnotations;

namespace Projekt.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required, StringLength(30)]
    public string Status { get; set; } = "Pending";

    // relacja do Customer
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
