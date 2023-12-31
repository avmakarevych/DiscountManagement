using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscountManagement.Web.Controllers;

[Route("Customers")]
public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;

    // public CustomersController(ICustomerService customerService)
    // {
    //     _customerService = customerService;
    // }
    public CustomersController(ICustomerService customerService, IOrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        var customers = _customerService.GetAllCustomers();
        return View(customers);
    }

    [HttpGet("{id}")]
    [Route("Details/{id}")]
    public IActionResult Details(Guid id)
    {
        var customer = _customerService.GetCustomer(id);
        if (customer == null)
            return NotFound();
        return View(customer);
    }
    
    [HttpGet]
    [Route("Create")]
    public IActionResult Create()
    {
        return View(new CustomerDTO());
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create(CustomerDTO customerDTO)
    {
        _customerService.AddCustomer(customerDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("Edit")]
    public IActionResult Edit(CustomerDTO customerDTO)
    {
        _customerService.UpdateCustomer(customerDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("{id}")]
    [Route("Delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        _customerService.DeleteCustomer(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet("{customerId}/orders")]
    public IActionResult CustomerOrders(Guid customerId)
    {
        var orders = _orderService.GetOrdersByCustomerId(customerId);

        if (orders == null || !orders.Any())
            return NotFound("Для цього клієнта замовлення відсутні.");

        return View(model: orders);
    }

}