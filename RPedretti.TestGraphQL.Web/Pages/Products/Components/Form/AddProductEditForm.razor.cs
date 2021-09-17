
using Fluxor;
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Web.Store;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components.Form;
public partial class AddProductEditForm
{
    [Inject] private IState<ProductsState> State { get; set; }

	[Parameter] public AddProductFormValues Model { get; set; }
	[Parameter] public EventCallback OnValidSubmit { get; set; }

    private string GetClassName => Model.ProductTypeId switch
    {
        1 => "book",
        2 => "pc",
        3 => "car",
        4 => "furniture",
        _ => ""
    };
}
