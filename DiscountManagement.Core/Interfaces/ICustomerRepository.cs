using DiscountManagement.Core.Entities;

namespace DiscountManagement.Core.Interfaces;

public interface ICustomerRepository
{
    Customer Get(Guid id);
    IEnumerable<Customer> GetAll();
    void Add(Customer customer);
    void Update(Customer customer);
    void Remove(Guid id);
}