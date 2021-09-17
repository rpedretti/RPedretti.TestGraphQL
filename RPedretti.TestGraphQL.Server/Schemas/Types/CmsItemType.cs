
using GraphQL.Types;
using RPedretti.TestGraphQL.Server.Repository.Models;

namespace RPedretti.TestGraphQL.Server.Schemas.Types;
public class CmsItemType : ObjectGraphType<CmsItem>
{
    public CmsItemType()
    {
        Field(c => c.CmsId);
        Field(c => c.LanguageId);
        Field(c => c.Text);
    }
}
