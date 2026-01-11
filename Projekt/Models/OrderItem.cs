using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models;

public class OrderItem
{
    public int Id { get; set; }

    // relacje
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 100000)]
    public int Quantity { get; set; }

    [Range(0.01, 100000)]
    [Precision(18, 2)]
    public decimal UnitPriceUSD { get; set; }
}
