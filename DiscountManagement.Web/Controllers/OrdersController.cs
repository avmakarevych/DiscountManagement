using Microsoft.AspNetCore.Mvc;
using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Web.Models;

namespace DiscountManagement.Web.Controllers;

[Route("Orders")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;

    public OrdersController(IOrderService orderService, ICustomerService customerService, IProductService productService)
    {
        _orderService = orderService;
        _customerService = customerService;
        _productService = productService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        var orders = _orderService.GetAllOrders();
        return View(orders);
    }

    [HttpGet]
    [Route("Details/{id}")]
    public IActionResult Details(Guid id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
            return NotFound();
        return View(order);
    }

    [HttpGet]
    [Route("Create")]
    public IActionResult Create()
    {
        var customers = _customerService.GetAllCustomers();
        ViewBag.Customers = customers;
        var products = _productService.GetAllProducts();
        ViewBag.Products = products;
        
        var selectedCustomer = customers.FirstOrDefault();
        if (selectedCustomer != null)
        {
            ViewBag.CustomerDiscount = selectedCustomer.Discount;
        }
        else
        {
            ViewBag.CustomerDiscount = 0;
        }

        return View();
    }


    [HttpPost]
    [Route("CreateOrder")]
    public IActionResult CreateOrder(OrderDTO orderDTO, string[] ProductIds, string[] Quantities)
    {
        if (ProductIds != null && Quantities != null && ProductIds.Length == Quantities.Length)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            for (int i = 0; i < ProductIds.Length; i++)
            {
                if (Guid.TryParse(ProductIds[i], out Guid productId))
                {
                    products.Add(new ProductDTO
                    {
                        Id = productId,
                        Quantity = int.Parse(Quantities[i])
                    });
                }

            }
            orderDTO.Products = products;
        }

        _orderService.AddOrder(orderDTO);
        return RedirectToAction("Index");
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