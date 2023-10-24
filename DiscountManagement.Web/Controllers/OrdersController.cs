using Microsoft.AspNetCore.Mvc;
using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Web.Models;

namespace DiscountManagement.Web.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var orders = _orderService.GetAllOrders();
        return View(orders);
    }

    [HttpGet("{id}")]
    public IActionResult Details(Guid id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
            return NotFound();
        return View(order);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(OrderDTO orderDTO)
    {
        _orderService.AddOrder(orderDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(Guid id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
            return NotFound();
        return View(order);
    }

    [HttpPost("edit/{id}")]
    public IActionResult Edit(OrderDTO orderDTO)
    {
        _orderService.UpdateOrder(orderDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        _orderService.DeleteOrder(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet("history/{customerId}")]
    public IActionResult OrderHistory(Guid customerId)
    {
        var orders = _orderService.GetOrdersByCustomerId(customerId);
        if (orders == null || !orders.Any())
            return NotFound();

        return View(orders);
    }
    [HttpGet("calculate-price/{orderId}")]
    public IActionResult CalculatePrice(Guid orderId)
    {
        decimal calculatedPrice;
        try
        {
            calculatedPrice = _orderService.CalculateTotalPrice(orderId);
        }
        catch (Exception ex)
        {
            var errorModel = new ErrorViewModel { Message = ex.Message };
            return View("Error", errorModel);
        }
        
        return View("CalculatePrice", calculatedPrice);
    }



}