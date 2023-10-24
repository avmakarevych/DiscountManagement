using System.Diagnostics;
using DiscountManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DiscountManagement.Web.Models;
using DiscountManagement.Application.Services;

namespace DiscountManagement.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        ICustomerService customerService,
        IOrderService orderService,
        IProductService productService,
        ILogger<HomeController> logger)
    {
        _customerService = customerService;
        _orderService = orderService;
        _productService = productService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var dashboardViewModel = new DashboardViewModel
        {
            TotalCustomers = _customerService.GetAllCustomers().Count(),
            TotalOrders = _orderService.GetAllOrders().Count(),
            TotalProducts = _productService.GetAllProducts().Count()
        };

        return View(dashboardViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}