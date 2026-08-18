using CiCdDemo.Api.Models;

namespace CiCdDemo.Api.Services;

public sealed class ProductService : IProductService
{
    private readonly List<Product> _products =
    [
        new(1, "Mechanical Keyboard", 129.99m),
        new(2, "Wireless Mouse", 59.99m),
        new(3, "USB-C Dock", 149.99m)
    ];

    public IReadOnlyCollection<Product> GetAll() => _products.AsReadOnly();

    public Product? GetById(int id) =>
        _products.FirstOrDefault(product => product.Id == id);

    public Product Create(CreateProductRequest request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Name);

        if (request.Price < 0)
            throw new ArgumentOutOfRangeException(nameof(request.Price));

        var nextId = _products.Count == 0 ? 1 : _products.Max(product => product.Id) + 1;
        var product = new Product(nextId, request.Name.Trim(), request.Price);
        _products.Add(product);
        return product;
    }
}
