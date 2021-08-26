
using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json;
using RPedretti.TestGraphQL.Server.Repository;
using RPedretti.TestGraphQL.Server.Repository.Models;
using RPedretti.TestGraphQL.Server.Schemas.Types;

namespace RPedretti.TestGraphQL.Server.Schemas.Query;
public class ProductMutation : ObjectGraphType
{
    public ProductMutation(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
    {
        Field<Product>(
            "createProduct",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ProductCreate>> { Name = "product" }
            ),
            resolve: context =>
            {
                var product = context.GetArgument<ProductDTO>("product");
                return productRepository.AddProductAsync(product);
            }
        );
        Field<ProductType>(
            "createProductType",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ProductTypeCreate>> { Name = "productType" }
            ),
            resolve: context =>
            {
                var productType = context.GetArgument<ProductTypeDTO>("productType");
                return productTypeRepository.AddProductTypeAsync(productType);
            }
        );
    }
}
