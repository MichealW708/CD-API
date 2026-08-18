using System.Net;
using System.Net.Http.Json;
using CiCdDemo.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CiCdDemo.Api.Tests;

public sealed class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/products");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetUnknownProduct_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/products/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateProduct_ReturnsCreated()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/products",
            new CreateProductRequest("Test Product", 49.99m));
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
