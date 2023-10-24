using DiscountManagement.Core.Interfaces;
using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Core.Entities;

namespace DiscountManagement.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
    }

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
    
    public IEnumerable<OrderDTO> GetOrdersByCustomerId(Guid customerId)
    {
        var orders = _orderRepository.GetAll().Where(o => o.CustomerId == customerId);
        return orders.Select(MapToDTO);
    }
    
    public decimal CalculateTotalPrice(Guid orderId)
    {
        var order = _orderRepository.Get(orderId);
        if (order == null)
            throw new Exception("Order not found.");

        var customer = _customerRepository.Get(order.CustomerId);
        if (customer == null)
            throw new Exception("Customer not found.");

        decimal total = 0;

        foreach (var product in order.Products)
        {
            total += product.Price;
        }

        total = total * (1 - customer.Discount / 100);
        return total;
    }



}
