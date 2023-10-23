namespace DiscountManagement.Application.DTOs;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string PersonalCode { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public decimal Discount { get; set; }
}