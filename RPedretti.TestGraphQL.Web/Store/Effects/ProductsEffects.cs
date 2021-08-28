
using Fluxor;
using RPedretti.TestGraphQL.Services;
using RPedretti.TestGraphQL.Web.Store.Actions;

namespace RPedretti.TestGraphQL.Web.Store.Effects;
public class FetchProductsActionEffect : Effect<FetchProductsAction>
{
    private readonly IProductService productService;

    public FetchProductsActionEffect(IProductService productService)
    {
        this.productService = productService;
    }

    public override async Task HandleAsync(FetchProductsAction action, IDispatcher dispatcher)
    {
        await Task.Delay(2000);
        var result = await productService.GetProducts(true);
        dispatcher.Dispatch(new FetchProductsResultAction(result));
    }
}

public class FetchProductTypessActionEffect : Effect<FetchProductTypesAction>
{
    private readonly IProductTypeService productTypeService;

    public FetchProductTypessActionEffect(IProductTypeService productTypeService)
    {
        this.productTypeService = productTypeService;
    }

    public override async Task HandleAsync(FetchProductTypesAction action, IDispatcher dispatcher)
    {
        await Task.Delay(2000);
        var result = await productTypeService.GetProductTypes();
        dispatcher.Dispatch(new FetchProductTypesResultAction(result));
    }
}