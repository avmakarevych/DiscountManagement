using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscountManagement.Web.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var customers = _customerService.GetAllCustomers();
        return View(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Details(Guid id)
    {
        var customer = _customerService.GetCustomer(id);
        if (customer == null)
            return NotFound();
        return View(customer);
    }

    [HttpPost]
    public IActionResult Create(CustomerDTO customerDTO)
    {
        _customerService.AddCustomer(customerDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Edit(CustomerDTO customerDTO)
    {
        _customerService.UpdateCustomer(customerDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("{id}")]
    public IActionResult Delete(Guid id)
    {
        _customerService.DeleteCustomer(id);
        return RedirectToAction(nameof(Index));
    }
}