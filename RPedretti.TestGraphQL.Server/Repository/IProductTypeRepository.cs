using RPedretti.TestGraphQL.Server.Repository.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public interface IProductTypeRepository
    {
        Task<ProductTypeDTO> GetProductTypeAsync(int id);
        Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync();
        Task<IDictionary<int, ProductTypeDTO>> GetProductTypeByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task<ProductTypeDTO> AddProductTypeAsync(ProductTypeDTO productType);
    }
}