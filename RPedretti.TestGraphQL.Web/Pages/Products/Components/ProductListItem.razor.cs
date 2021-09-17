
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Web.Pages.Products.Model;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components;
public partial class ProductListItem
{
    [Parameter] public ProductModel Product { get; set; }

    [Parameter] public EventCallback<(int productId, bool @checked)> OnCheckedChange { get; set; }

    private async Task HandleChecked(ChangeEventArgs @event)
    {
        var @checked = (bool)@event.Value;
        await OnCheckedChange.InvokeAsync((Product.ProductId.Value, @checked));
    }
}
