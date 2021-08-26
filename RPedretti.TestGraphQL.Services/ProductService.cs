
using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Types;

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
}
