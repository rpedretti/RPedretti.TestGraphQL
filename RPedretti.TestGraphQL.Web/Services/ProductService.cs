
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Services;
public sealed class ProductService : IProductService
{
    private const string _controller = "/api/products";
    private readonly HttpClient _httpClient;

    public ProductService(IWebApiClient httpClient)
    {
        _httpClient = httpClient.HttpClient;
    }

    public async Task AddProduct(string name, int productTypeId)
    {
        await _httpClient.PostAsJsonAsync($"{_controller}/product", new
        {
            ProductName = name,
            ProductTypeId = productTypeId
        });
    }

    public async Task<Product> GetProductAsync(int productId, bool withProductType = false)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"{_controller}/product?productId={productId}&withProductType={withProductType}");
    }

    public async Task<ICollection<Product>> GetProductsAsync(bool withProductType = false)
    {
        return await _httpClient.GetFromJsonAsync<ICollection<Product>>($"{_controller}/products?withProductType={withProductType}");
    }
}
