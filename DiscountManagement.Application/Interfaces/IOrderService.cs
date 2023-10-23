using DiscountManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Application.Interfaces;

public interface IOrderService
{
    OrderDTO GetOrder(Guid id);
    IEnumerable<OrderDTO> GetAllOrders();
    void AddOrder(OrderDTO orderDTO);
    void UpdateOrder(OrderDTO orderDTO);
    void DeleteOrder(Guid id);
}