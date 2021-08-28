
using Fluxor;

namespace RPedretti.TestGraphQL.Web.Store;
public class Feature : Feature<ProductsState>
{
    override public string GetName() => "Products";
    protected override ProductsState GetInitialState() => new(null, null);
}
