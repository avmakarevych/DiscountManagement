using DiscountManagement.Application.DTOs;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Core.Interfaces;
using DiscountManagement.Core.Entities;

namespace DiscountManagement.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductDTO GetProduct(Guid id)
    {
        var product = _productRepository.Get(id);
        return MapToDTO(product);
    }

    public IEnumerable<ProductDTO> GetAllProducts()
    {
        var products = _productRepository.GetAll();
        return products.Select(MapToDTO);
    }

    public void AddProduct(ProductDTO productDTO)
    {
        var product = MapToEntity(productDTO);
        _productRepository.Add(product);
    }

    public void UpdateProduct(ProductDTO productDTO)
    {
        var product = MapToEntity(productDTO);
        _productRepository.Update(product);
    }

    public void DeleteProduct(Guid id)
    {
        _productRepository.Remove(id);
    }

    private ProductDTO MapToDTO(Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    private Product MapToEntity(ProductDTO productDTO)
    {
        return new Product
        {
            Id = productDTO.Id,
            Name = productDTO.Name,
            Price = productDTO.Price
        };
    }
}