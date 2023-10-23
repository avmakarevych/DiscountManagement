using DiscountManagement.Core.Entities;

namespace DiscountManagement.Core.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Order Get(Guid id);
    IEnumerable<Order> GetByCustomerId(Guid customerId);
    void Add(Order order);
    void Update(Order order);
    void Remove(Guid id);
    IEnumerable<Order> GetAll();
}