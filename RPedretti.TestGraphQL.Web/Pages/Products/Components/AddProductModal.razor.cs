
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RPedretti.TestGraphQL.Web.Models;
using RPedretti.TestGraphQL.Web.Pages.Products.Components.Form;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components;
public partial class AddProductModal
{
    [Parameter] public EventCallback<AddProductModel> OnAdd { get; set; }
    [Parameter] public EventCallback OnDismiss { get; set; }
    [Parameter] public bool IsOpen { get; set; }

    private EditContext EditContext;
    private AddProductFormValues Model;

    protected override void OnInitialized()
	{
		Model = new();
        EditContext = new(Model);
	}

    private async Task HandleClose()
	{
        Model = new();
        EditContext = new(Model);
        await OnDismiss.InvokeAsync();
    }

	private async Task HandleAdd()
    {
        if (EditContext.Validate())
        {
            var mapped = new AddProductModel(Model.ProductName, Model.ProductTypeId.Value);
            await OnAdd.InvokeAsync(mapped);
            Model = new();
            EditContext = new(Model);
        }
    }
}
