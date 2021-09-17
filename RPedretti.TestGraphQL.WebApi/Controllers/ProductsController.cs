using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPedretti.TestGraphQL.Services;
using RPedretti.TestGraphQL.Types;
using RPedretti.TestGraphQL.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductTypeService _productTypeService;

    public ProductsController(IProductService productService, IProductTypeService productTypeService)
    {
        _productService = productService;
        _productTypeService = productTypeService;
    }

    [HttpGet("products")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    public async Task<IActionResult> GetProductsAsync([FromQuery] bool withProductType)
    {
        var products = await _productService.GetProducts(withProductType);
        return Ok(products);
    }

    [HttpGet("product")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> GetProductAsync([FromQuery] GetProductRequestModel requestModel)
    {
        var product = await _productService.GetProduct(requestModel.ProductId, requestModel.WithProductType);
        return Ok(product);
    }

    [HttpPost("product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest addProductRequest)
    {
        await _productService.AddProduct(addProductRequest.ProductName!, addProductRequest.ProductTypeId);
        return Ok();
    }

    [HttpGet("productTypes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductType>))]
    public async Task<IActionResult> GetProductTypesAsync()
    {
        var productTypes = await _productTypeService.GetProductTypes();
        return Ok(productTypes);
    }

    [HttpGet("productType")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> GetProductTypeAsync([FromQuery] GetProductTypeRequestModel requestModel)
    {
        var productType = await _productTypeService.GetProductType(requestModel.ProductTypeId);
        return Ok(productType);
    }
}
