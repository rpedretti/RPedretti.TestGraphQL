using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Services;

public interface IProductService
{
    Task<Product> GetProductAsync(int productId, bool withProductType = false);
    Task<ICollection<Product>> GetProductsAsync(bool withProductType = false);
    Task AddProduct(string name, int productTypeId);
}
