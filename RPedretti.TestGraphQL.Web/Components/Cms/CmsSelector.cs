using Fluxor;
using RPedretti.TestGraphQL.Web.State;

namespace RPedretti.TestGraphQL.Web.Components.Cms;

public class CmsSelector : ICmsSelector
{
    private readonly IState<CmsState> cmsState;

    public CmsSelector(IState<CmsState> cmsState)
    {
        this.cmsState = cmsState;
    }

    public CmsItem this[CmsItem cms]
    {
        get
        {
            cmsState.Value.Cms.TryGetValue(cms.Id, out CmsItem? item);
            return item ?? cms;
        }
    }
}
