using Microsoft.EntityFrameworkCore;
using RPedretti.TestGraphQL.Server.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext dbContext;

        public ProductTypeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductTypeDTO> AddProductTypeAsync(ProductTypeDTO productType)
        {
            var result = await dbContext.ProductTypes.AddAsync(productType);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductTypeDTO> GetProductTypeAsync(int id) =>
            await dbContext.ProductTypes.Where(p => p.ProductTypeId == id).FirstOrDefaultAsync();

        public async Task<IDictionary<int, ProductTypeDTO>> GetProductTypeByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken) =>
            await dbContext.ProductTypes
                .Where(p => ids.Contains(p.ProductTypeId))
                .ToDictionaryAsync(p => p.ProductTypeId, cancellationToken);

        public async Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync() =>
            await dbContext.ProductTypes.ToListAsync();
    }
}
