using CiCdDemo.Api.Models;

namespace CiCdDemo.Api.Services;

public interface IProductService
{
    IReadOnlyCollection<Product> GetAll();
    Product? GetById(int id);
    Product Create(CreateProductRequest request);
}
