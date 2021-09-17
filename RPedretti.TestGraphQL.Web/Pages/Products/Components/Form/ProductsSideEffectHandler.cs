
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components.Form;
public class ProductsSideEffectHandler : ComponentBase, IDisposable
{
    [CascadingParameter] private EditContext EditContext { get; set; }
    [Inject] private ILogger<ProductsSideEffectHandler> Logger { get; set; }

    private void HandleChange(object _, FieldChangedEventArgs args)
    {
        var identifier = args.FieldIdentifier;
        switch (identifier.FieldName)
        {
            case nameof(AddProductFormValues.ProductTypeId):
                HandleNameChange();
                break;
        };
    }

    private void HandleNameChange()
    {
        Model.ProductName = Model.ProductTypeId switch
        {
            1 => "My book",
            2 => "My PC",
            3 => "My car",
            4 => "My furniture",
            _ => "unmapped"
        };
    }

    private AddProductFormValues Model => EditContext.Model as AddProductFormValues;

    protected override void OnInitialized()
    {
        EditContext.OnFieldChanged += HandleChange;
    }

    public void Dispose()
    {
        EditContext.OnFieldChanged -= HandleChange;
        GC.SuppressFinalize(this);
    }
}
