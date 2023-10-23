using System.ComponentModel.DataAnnotations;
namespace DiscountManagement.Core.Entities;

public class Customer
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string PersonalCode { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    
    [StringLength(250)]
    public string Address { get; set; }

    [Range(0, 100)]
    public decimal Discount { get; set; }

    public List<Order> Orders { get; set; }
}