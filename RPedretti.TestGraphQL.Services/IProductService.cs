using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Services
{
    public interface IProductService
    {
        Task<Product?> GetProduct(int productId, bool withProductType = false);
        Task<ICollection<Product>> GetProducts(bool withProductType = false);
        Task<Product> AddProduct(string productName, int productTypeId);
    }
}