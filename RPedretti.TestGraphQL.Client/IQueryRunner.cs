using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Client
{
    public interface IQueryRunner
    {
        Task<IEnumerable<Product>> RunQuery(ProductQueryBuilder productBuilder);
        Task<Product?> RunQuery(ProductQueryBuilder productBuilder, int productId);
        Task<IEnumerable<ProductType>> RunQuery(ProductTypeQueryBuilder productTypeBuilder);
        Task<ProductType?> RunQuery(ProductTypeQueryBuilder productTypeBuilder, int productTypeId);
    }
}