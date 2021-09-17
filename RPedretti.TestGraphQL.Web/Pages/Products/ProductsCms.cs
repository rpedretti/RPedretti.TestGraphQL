using RPedretti.TestGraphQL.Web.Components.Cms;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.Pages.Products;

public class ProductsCms
{
    public static readonly CmsItem ProductsLabel = new(1, "Products");
    public static readonly CmsItem AddProductButton = new(2, "Add product");
    public static readonly CmsItem ProductLabel = new(3, "Product");
    public static readonly CmsItem SelectedLabel = new(4, "Selected");
    public static readonly CmsItem ProductTypeLabel = new(5, "Product type");

    public static readonly IReadOnlySet<CmsItem> Messages = new HashSet<CmsItem>
        {
            ProductsLabel,
            AddProductButton,
            ProductLabel,
            SelectedLabel,
            ProductTypeLabel
        };
}
