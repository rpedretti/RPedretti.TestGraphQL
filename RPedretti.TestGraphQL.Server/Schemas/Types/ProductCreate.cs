
using GraphQL.Types;

namespace RPedretti.TestGraphQL.Server.Schemas.Types;
public class ProductCreate : InputObjectGraphType
{
    public ProductCreate()
    {
        Name = "ProductCreate";
        Field<NonNullGraphType<StringGraphType>>("productName");
        Field<NonNullGraphType<IntGraphType>>("productTypeId");
    }
}
