using DiscountManagement.Application.DTOs;


namespace DiscountManagement.Application.Interfaces;

public interface ICustomerService
{
    CustomerDTO GetCustomer(Guid id);
    IEnumerable<CustomerDTO> GetAllCustomers();
    void AddCustomer(CustomerDTO customerDTO);
    void UpdateCustomer(CustomerDTO customerDTO);
    void DeleteCustomer(Guid id);
}