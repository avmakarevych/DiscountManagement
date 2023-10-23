using System.ComponentModel.DataAnnotations;
namespace DiscountManagement.Core.Entities;

public class Product
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public Guid OrderId { get; set; }

    public Order Order { get; set; }
}