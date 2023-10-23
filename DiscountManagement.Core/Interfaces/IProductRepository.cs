using DiscountManagement.Core.Entities;

namespace DiscountManagement.Core.Interfaces;

public interface IProductRepository
{
    Product Get(Guid id);
    IEnumerable<Product> GetByOrderId(Guid orderId);
    void Add(Product product);
    void Update(Product product);
    void Remove(Guid id);
}