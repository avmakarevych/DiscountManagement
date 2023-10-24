namespace DiscountManagement.Application.DTOs;

public class OrderDTO
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<ProductDTO> Products { get; set; }
    public decimal CustomerDiscount { get; set; }
    public Guid[] ProductIds { get; set; }
    public int[] Quantities { get; set; } 
}