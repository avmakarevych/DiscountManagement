using DiscountManagement.Core.Interfaces;
using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Core.Entities;

namespace DiscountManagement.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderDTO GetOrder(Guid id)
    {
        var order = _orderRepository.Get(id);
        return MapToDTO(order);
    }

    public IEnumerable<OrderDTO> GetAllOrders()
    {
        var orders = _orderRepository.GetAll();
        return orders.Select(MapToDTO);
    }

    public void AddOrder(OrderDTO orderDTO)
    {
        var order = MapToEntity(orderDTO);
        _orderRepository.Add(order);
    }

    public void UpdateOrder(OrderDTO orderDTO)
    {
        var order = MapToEntity(orderDTO);
        _orderRepository.Update(order);
    }

    public void DeleteOrder(Guid id)
    {
        _orderRepository.Remove(id);
    }

    private OrderDTO MapToDTO(Order order)
    {
        return new OrderDTO
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Products = order.Products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToList()
        };
    }

    private Order MapToEntity(OrderDTO orderDTO)
    {
        return new Order
        {
            Id = orderDTO.Id,
            CustomerId = orderDTO.CustomerId,
            Products = orderDTO.Products.Select(productDTO => new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price
            }).ToList()
        };
    }

}
