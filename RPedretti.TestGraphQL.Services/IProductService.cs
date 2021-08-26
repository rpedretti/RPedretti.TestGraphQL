using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Services
{
    public interface IProductService
    {
        Task<Product?> GetProduct(int productId, bool withProductType = false);
        Task<ICollection<Product>> GetProducts(bool withProductType = false);
    }
}