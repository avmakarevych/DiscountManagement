using DiscountManagement.Application.DTOs;

namespace DiscountManagement.Application.Interfaces;

public interface IOrderService
{
    OrderDTO GetOrder(Guid id);
    IEnumerable<OrderDTO> GetAllOrders();
    void AddOrder(OrderDTO orderDTO);
    void UpdateOrder(OrderDTO orderDTO);
    void DeleteOrder(Guid id);
    IEnumerable<OrderDTO> GetOrdersByCustomerId(Guid customerId);
    decimal CalculateTotalPrice(Guid orderId);
}