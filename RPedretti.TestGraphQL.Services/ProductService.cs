using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Services;
public class ProductService : IProductService
{
    private readonly IQueryRunner client;

    public ProductService(IQueryRunner client)
    {
        this.client = client;
    }

    public async Task<ICollection<Product>> GetProducts(bool withProductType = false)
    {
        var builder = new ProductQueryBuilder()
                .WithProductId()
                .WithProductName();
        if (withProductType)
        {
            builder.WithProductType(
                new ProductTypeQueryBuilder()
                    .WithProductTypeId()
                    .WithProductTypeName()
            );
        }

        return (await client.RunQuery(builder)).ToList();
    }

    public async Task<Product?> GetProduct(int productId, bool withProductType = false)
    {
        var builder = new ProductQueryBuilder()
                .WithProductId()
                .WithProductName();
        if (withProductType)
        {
            builder.WithProductType(
                new ProductTypeQueryBuilder()
                    .WithProductTypeId()
                    .WithProductTypeName()
            );
        }

        return await client.RunQuery(builder, productId);
    }

	public async Task<Product> AddProduct(string productName, int productTypeId)
	{
        var builder = new ProductCreate
        {
            ProductName = productName,
            ProductTypeId = productTypeId
        };

        return await client.RunQuery(builder);
    }
}
