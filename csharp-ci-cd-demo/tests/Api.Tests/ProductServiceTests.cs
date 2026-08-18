using CiCdDemo.Api.Models;
using CiCdDemo.Api.Services;

namespace CiCdDemo.Api.Tests;

public sealed class ProductServiceTests
{
    [Fact]
    public void GetById_ReturnsExpectedProduct()
    {
        var service = new ProductService();
        var product = service.GetById(1);
        Assert.NotNull(product);
        Assert.Equal("Mechanical Keyboard", product.Name);
    }

    [Fact]
    public void Create_AssignsNextId()
    {
        var service = new ProductService();
        var product = service.Create(new CreateProductRequest("Monitor", 299.99m));
        Assert.Equal(4, product.Id);
    }

    [Fact]
    public void Create_RejectsNegativePrice()
    {
        var service = new ProductService();
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            service.Create(new CreateProductRequest("Monitor", -1m)));
    }
}
