using RPedretti.TestGraphQL.Server.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductAsync(int id);
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
    }
}