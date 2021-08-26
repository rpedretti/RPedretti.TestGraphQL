
using GraphQL.Types;

namespace RPedretti.TestGraphQL.Server.Schemas.Types;
public class ProductTypeCreate : InputObjectGraphType
{
    public ProductTypeCreate()
    {
        Name = "ProductTypeCreate";
        Field<NonNullGraphType<StringGraphType>>("productTypeName");
    }
}
