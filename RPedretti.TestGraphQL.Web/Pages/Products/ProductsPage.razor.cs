
using Fluxor;
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Web.Models;
using RPedretti.TestGraphQL.Web.Pages.Products.Model;
using RPedretti.TestGraphQL.Web.Store;
using RPedretti.TestGraphQL.Web.Store.Actions;
using System.Collections.Generic;
using System.Linq;

namespace RPedretti.TestGraphQL.Web.Pages.Products;
public partial class ProductsPage
{
	private bool loadingProducts = true;
	private bool loadingCms = true;
	private ICollection<ProductModel>? products;
	private bool isOpen = false;

	[Inject] IState<ProductsState> ProductsState { get; set; }
	[Inject] IDispatcher Dispatcher { get; set; }

	private bool Loading => loadingCms || loadingProducts;

	protected override void OnInitialized()
	{
		var fetchProducts = new FetchProductsAction();
		var fetchProductTypes = new FetchProductTypesAction();
		Dispatcher.Dispatch(fetchProducts);
		Dispatcher.Dispatch(fetchProductTypes);
		Dispatcher.Dispatch(new FetchCmsAction(ProductsCms.Messages, () =>
		{
			loadingCms = false;
		}));
		ProductsState.StateChanged += (_, s) => StateChanged(s);
	}

	private void StateChanged(ProductsState state)
	{
		loadingProducts = state.Products == null || state.ProductTypes == null;

		products = state.Products?.Select(p => new ProductModel {
			ProductId = p.ProductId,
			ProductName = p.ProductName!,
			ProductType = new ProductTypeModel
            {
				ProductTypeId = p.ProductType?.ProductTypeId,
				ProductTypeName = p.ProductType?.ProductTypeName,

            },
			Selected = false
		})?.ToList();
		StateHasChanged();
	}

	private void HandleChecked((int productId, bool @checked) value)
    {
		products = products?.Select(p =>
		{
			if (p.ProductId == value.productId)
			{
				return new ProductModel
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName,
					ProductType = p.ProductType,
					Selected = value.@checked
				};
			}

			return p;
		})?.ToList();
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
		Dispatcher.Dispatch(new AddProductAction(productModel));
	}
}
