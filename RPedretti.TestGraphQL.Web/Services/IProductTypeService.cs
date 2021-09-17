using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Services;

public interface IProductTypeService
{
    Task<ProductType> GetProductTypeAsync(int productTypeId);
    Task<ICollection<ProductType>> GetProductTypesAsync(bool withProductType = false);
}
