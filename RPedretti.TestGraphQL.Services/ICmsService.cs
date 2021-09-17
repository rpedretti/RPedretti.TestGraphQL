using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Services
{
    public interface ICmsService
    {
        Task<ICollection<CmsItemType>> GetCmsAsync(IEnumerable<int> cmsIds, int languageId, bool withId);
    }
}