using GraphQL.Types;
using RPedretti.TestGraphQL.Server.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Schemas.Types
{
    public class ProductType : ObjectGraphType<ProductTypeDTO>
    {
        public ProductType()
        {
            Field(p => p.ProductTypeId);
            Field(p => p.ProductTypeName);
        }
    }
}
