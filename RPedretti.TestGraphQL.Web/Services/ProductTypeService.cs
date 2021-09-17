
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Services;
public sealed class ProductTypeService : IProductTypeService
{
    private const string _controller = "/api/products";
    private readonly HttpClient _httpClient;

    public ProductTypeService(IWebApiClient httpClient)
    {
        _httpClient = httpClient.HttpClient;
    }

    public async Task<ProductType> GetProductTypeAsync(int productTypeId)
    {
        return await _httpClient.GetFromJsonAsync<ProductType>($"{_controller}/productType?productTupeId={productTypeId}");
    }

    public async Task<ICollection<ProductType>> GetProductTypesAsync(bool withProductType = false)
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ProductType>>($"{_controller}/productTypes");
    }
}
