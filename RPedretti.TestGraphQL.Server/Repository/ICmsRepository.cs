using RPedretti.TestGraphQL.Server.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Server.Repository
{
    public interface ICmsRepository
    {
        Task<ICollection<CmsItem>> GetCmsAsync(IEnumerable<int> ids, int languageId);
    }
}