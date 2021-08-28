
using Fluxor;
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Web.Store;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components.Form;
public partial class AddProductEditForm
{
    [Inject] private IState<ProductsState> State { get; set; }

	[Parameter] public AddProductFormValues Model { get; set; }
	[Parameter] public EventCallback OnValidSubmit { get; set; }
}
