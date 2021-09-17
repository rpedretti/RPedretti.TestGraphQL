using Microsoft.EntityFrameworkCore;
using RPedretti.TestGraphQL.Server.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO product)
        {
            var result = await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductDTO> GetProductAsync(int id) =>
            await dbContext.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync() =>
            await dbContext.Products.ToListAsync();
    }
}
