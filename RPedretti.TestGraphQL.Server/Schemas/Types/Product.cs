using GraphQL.Types;
using GraphQL.MicrosoftDI;
using RPedretti.TestGraphQL.Server.Repository.Models;
using RPedretti.TestGraphQL.Server.Repository;
using GraphQL.DataLoader;

namespace RPedretti.TestGraphQL.Server.Schemas.Types
{
    public class Product : ObjectGraphType<ProductDTO>
    {
        public Product()
        {
            Field(p => p.ProductId);
            Field(p => p.ProductName);

            Field<ProductType>()
                .Name("productType")
                .Resolve()
                .WithServices<IProductTypeRepository, IDataLoaderContextAccessor>()
                .Resolve((context, service, dataLoader) =>
                {
                    var loader = dataLoader.Context.GetOrAddBatchLoader<int, ProductTypeDTO>("GetProductTypesById", service.GetProductTypeByIdsAsync);
                    return loader.LoadAsync(context.Source.ProductTypeId);
                });

        }
    }
}