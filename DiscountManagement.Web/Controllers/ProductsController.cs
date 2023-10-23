using Microsoft.AspNetCore.Mvc;
using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;

namespace DiscountManagement.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }

    [HttpGet("{id}")]
    public IActionResult Details(Guid id)
    {
        var product = _productService.GetProduct(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(ProductDTO productDTO)
    {
        _productService.AddProduct(productDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(Guid id)
    {
        var product = _productService.GetProduct(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    [HttpPost("edit/{id}")]
    public IActionResult Edit(ProductDTO productDTO)
    {
        _productService.UpdateProduct(productDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }
}