
using Fluxor;
using RPedretti.TestGraphQL.Web.Components.Cms;
using RPedretti.TestGraphQL.Web.State;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.Store;
public class Feature : Feature<ProductsState>
{
    override public string GetName() => "Products";
    protected override ProductsState GetInitialState() => new(null, null);
}

public class CmsFeature : Feature<CmsState>
{
    public override string GetName() => "Cms";

    protected override CmsState GetInitialState() => new(new Dictionary<int, CmsItem>(), new HashSet<int>());
}
