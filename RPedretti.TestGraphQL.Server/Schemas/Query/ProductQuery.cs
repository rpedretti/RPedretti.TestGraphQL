using GraphQL;
using GraphQL.Types;
using RPedretti.TestGraphQL.Server.Repository;
using RPedretti.TestGraphQL.Server.Schemas.Types;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Server.Schemas.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(
            IProductRepository productRepository,
            IProductTypeRepository productTypeRepository,
            ICmsRepository cmsRepository
        )
        {
            Field<ListGraphType<Product>>(
                "products",
                resolve: context => productRepository.GetProductsAsync()
            );

            Field<Product>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" }
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
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productTypeId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("productTypeId");
                    return productTypeRepository.GetProductTypeAsync(id);
                }
            );

            Field<ListGraphType<CmsItemType>>(
                "cms",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<IntGraphType>>>> { Name = "cmsIds" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "languageId" }
                ),
                resolve: context =>
                {
                    var ids = context.GetArgument<IEnumerable<int>>("cmsIds");
                    var languageId = context.GetArgument<int>("languageId");
                    return cmsRepository.GetCmsAsync(ids, languageId);
                }
            );
        }
    }
}
