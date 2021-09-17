
using Fluxor;
using RPedretti.TestGraphQL.Web.Services;
using RPedretti.TestGraphQL.Web.Store.Actions;
using System.Threading.Tasks;

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
        var result = await productService.GetProductsAsync(true);
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
        var result = await productTypeService.GetProductTypesAsync();
        dispatcher.Dispatch(new FetchProductTypesResultAction(result));
    }
}

public class AddProductActionEffect : Effect<AddProductAction>
{
    private readonly IProductService productService;

    public AddProductActionEffect(IProductService productService)
    {
        this.productService = productService;
    }

    public override async Task HandleAsync(AddProductAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ClearProductsAction());
        await Task.Delay(2000);
        var model = action.Model;
        await productService.AddProduct(model.Name, model.ProductTypeId);
        dispatcher.Dispatch(new FetchProductsAction());
    }
}