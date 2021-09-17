
namespace RPedretti.TestGraphQL.Web.Pages.Products.Model;
public class ProductModel
{
    public int? ProductId { get; set; }
    public string ProductName { get; set; }
    public ProductTypeModel? ProductType { get; set; }
    public bool Selected { get; set; }
}
