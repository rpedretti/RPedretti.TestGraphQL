using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Services
{
    public class CmsService : ICmsService
    {
        private readonly IQueryRunner client;

        public CmsService(IQueryRunner client)
        {
            this.client = client;
        }

        public async Task<ICollection<CmsItemType>> GetCmsAsync(IEnumerable<int> cmsIds, int languageId, bool withId)
        {
            var builder = new CmsItemTypeQueryBuilder()
                .WithCmsId()
                .WithLanguageId()
                .WithText();
            var messages = await client.RunQuery(builder, cmsIds, languageId);
            messages = withId
                ? messages.Select(m => new CmsItemType { Text = $"{GetId(m)}{m.Text}", CmsId = m.CmsId })
                : messages;
            return messages.ToList();

        }

        private static string GetId(CmsItemType cms) => $"{cms.CmsId}: ";

    }
}
