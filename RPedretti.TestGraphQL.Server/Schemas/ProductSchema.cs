using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using RPedretti.TestGraphQL.Server.Schemas.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IServiceProvider serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ProductQuery>();
        }
    }
}
