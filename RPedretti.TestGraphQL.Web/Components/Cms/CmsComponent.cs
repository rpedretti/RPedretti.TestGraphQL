using Fluxor;
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Web.Services;
using RPedretti.TestGraphQL.Web.State;

namespace RPedretti.TestGraphQL.Web.Components.Cms;

public abstract class CmsComponent : ComponentBase
{
    [Inject] IState<CmsState> CmsState { get; set; }
    [Inject] protected ICmsService CmsService { get; set; }

    protected override void OnInitialized()
    {
        CmsState.StateChanged += (s, e) => StateHasChanged();
        base.OnInitialized();
    }
}
