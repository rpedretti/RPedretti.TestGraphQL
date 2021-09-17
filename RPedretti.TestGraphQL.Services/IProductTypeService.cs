using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Services
{
    public interface IProductTypeService
    {
        Task<ProductType?> GetProductType(int productTypeId);
        Task<ICollection<ProductType>> GetProductTypes();
    }
}