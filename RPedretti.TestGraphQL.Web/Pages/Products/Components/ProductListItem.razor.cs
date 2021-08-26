
using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components;
public partial class ProductListItem
{
    [Parameter] public Product Product { get; set; }
}
