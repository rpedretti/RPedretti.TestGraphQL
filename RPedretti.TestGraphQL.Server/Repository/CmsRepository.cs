
using RPedretti.TestGraphQL.Server.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace RPedretti.TestGraphQL.Server.Repository;
public class CmsRepository : ICmsRepository
{
    private readonly AppDbContext dbContext;

    public CmsRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ICollection<CmsItem>> GetCmsAsync(IEnumerable<int> ids, int languageId)
    {
        return await dbContext.Cms
            .Where(c => ids.Contains(c.CmsId) && c.LanguageId == languageId)
            .ToListAsync();
    }
}
