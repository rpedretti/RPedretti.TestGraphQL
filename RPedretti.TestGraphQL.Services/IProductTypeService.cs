using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Services
{
    public interface IProductTypeService
    {
        Task<ProductType?> GetProductType(int productTypeId);
        Task<ICollection<ProductType>> GetProductTypes();
    }
}