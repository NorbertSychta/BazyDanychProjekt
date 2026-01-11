using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string NamePL { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string NameEN { get; set; } = string.Empty;

    [Range(0.01, 100000)]
    [Precision(18, 2)]
    public decimal PriceUSD { get; set; }

    [Range(0, 100000)]
    public int StockQuantity { get; set; }
}
