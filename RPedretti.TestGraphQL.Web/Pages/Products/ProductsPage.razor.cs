
using Fluxor;
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Types;
using RPedretti.TestGraphQL.Web.Models;
using RPedretti.TestGraphQL.Web.Store;
using RPedretti.TestGraphQL.Web.Store.Actions;

namespace RPedretti.TestGraphQL.Web.Pages.Products;
public partial class ProductsPage
{
	private bool loading = true;
	private ICollection<Product> products;
	private bool isOpen = false;

	[Inject] IState<ProductsState> ProductsState { get; set; }
	[Inject] IDispatcher Dispatcher { get; set; }

	protected override void OnInitialized()
	{
		var fetchProducts = new FetchProductsAction();
		var fetchProductTypes = new FetchProductTypesAction();
		Dispatcher.Dispatch(fetchProducts);
		Dispatcher.Dispatch(fetchProductTypes);
		ProductsState.StateChanged += StateChanged;
	}

	private void StateChanged(object sender, ProductsState state)
	{
		products = state.Products;
		loading = products == null && state.ProductTypes != null;
		StateHasChanged();
	}

	private void OpenModal()
	{
		isOpen = true;
	}

	private void HandleClose()
	{
		isOpen = false;
	}

	private void HandleAdd(AddProductModel productModel)
	{
		isOpen = false;
	}
}
