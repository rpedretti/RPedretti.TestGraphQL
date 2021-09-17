using RPedretti.TestGraphQL.Web.Components.Cms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Services
{
    public interface ICmsService
    {
        string Get(CmsItem cmsItem, params object?[] args);

        Task<IEnumerable<CmsItem>> FetchCmsAsync(IEnumerable<CmsItem> items);
    }
}