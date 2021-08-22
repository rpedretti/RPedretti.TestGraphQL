using GraphQL;
using GraphQL.Types;
using RPedretti.TestGraphQL.Server.Repository;
using RPedretti.TestGraphQL.Server.Schemas.Types;

namespace RPedretti.TestGraphQL.Server.Schemas.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            Field<ListGraphType<Product>>(
                "products",
                resolve: context => productRepository.GetProductsAsync()
            );

            Field<Product>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "productId" }
                ),
                resolve: context => {
                    var id = context.GetArgument<int>("productId");
                    return productRepository.GetProductAsync(id);
                }
            );

            Field<ListGraphType<ProductType>>(
                "productTypes",
                resolve: context => productTypeRepository.GetProductTypesAsync()
            );

            Field<ProductType>(
                "productType",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "productTypeId" }
                ),
                resolve: context => {
                    var id = context.GetArgument<int>("productTypeId");
                    return productTypeRepository.GetProductTypeAsync(id);
                }
            );
        }
    }
}
