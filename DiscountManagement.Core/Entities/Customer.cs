namespace DiscountManagement.Core.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string PersonalCode { get; set; } // Особовий код
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Discount { get; set; } // Знижка у відсотках
    public List<Order> Orders { get; set; }
}