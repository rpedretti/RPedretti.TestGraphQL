
using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Services;
public class ProductTypeService : IProductTypeService
{
    private readonly IQueryRunner client;

    public ProductTypeService(IQueryRunner client)
    {
        this.client = client;
    }

    public async Task<ICollection<ProductType>> GetProductTypes()
    {
        var builder = new ProductTypeQueryBuilder()
                .WithProductTypeId()
                .WithProductTypeName();

        return (await client.RunQuery(builder)).ToList();
    }

    public async Task<ProductType?> GetProductType(int productTypeId)
    {
        var builder = new ProductTypeQueryBuilder()
                .WithProductTypeId()
                .WithProductTypeName();

        return await client.RunQuery(builder, productTypeId);
    }
}
