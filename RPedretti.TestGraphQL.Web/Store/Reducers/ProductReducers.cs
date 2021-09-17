
using Fluxor;
using RPedretti.TestGraphQL.Web.Store.Actions;

namespace RPedretti.TestGraphQL.Web.Store.Reducers;
public static class ProductReducers
{
    [ReducerMethod]
    public static ProductsState ReduceClearProductsResultAction(ProductsState state, ClearProductsAction _) =>
        state with { Products = null };

    [ReducerMethod]
    public static ProductsState ReduceFetchProductsResultAction(ProductsState state, FetchProductsResultAction action) =>
        state with { Products = action.Products };

    [ReducerMethod]
    public static ProductsState ReduceFetchProductTypesResultAction(ProductsState state, FetchProductTypesResultAction action) =>
        state with { ProductTypes = action.ProductTypes };
}
