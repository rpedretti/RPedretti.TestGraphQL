
using System.ComponentModel.DataAnnotations;

namespace RPedretti.TestGraphQL.Web.Pages.Products.Components.Form;
public class AddProductFormValues
{
    [Required(ErrorMessage = "Please add a product name")]
    [StringLength(50, ErrorMessage = "Name should not be greater then 50 characters")]
	public string ProductName { get; set; } 

    [Required(ErrorMessage = "Please select a product type")]
	public int? ProductTypeId { get; set; }
}
