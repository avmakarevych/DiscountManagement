using System.ComponentModel.DataAnnotations;
namespace DiscountManagement.Core.Entities;

public class Order
{
    public Guid Id { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }

    public List<Product> Products { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }
}