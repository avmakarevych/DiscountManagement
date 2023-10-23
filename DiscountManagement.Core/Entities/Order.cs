namespace DiscountManagement.Core.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public DateTime OrderDate { get; set; }
}