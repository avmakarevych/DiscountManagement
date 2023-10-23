using DiscountManagement.Application.DTOs;

namespace DiscountManagement.Application.Interfaces;

public interface IProductService
{
    ProductDTO GetProduct(Guid id);
    IEnumerable<ProductDTO> GetAllProducts();
    void AddProduct(ProductDTO productDTO);
    void UpdateProduct(ProductDTO productDTO);
    void DeleteProduct(Guid id);
}