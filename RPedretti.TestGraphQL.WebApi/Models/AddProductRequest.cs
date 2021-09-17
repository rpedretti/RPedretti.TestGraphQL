
using System.ComponentModel.DataAnnotations;

namespace RPedretti.TestGraphQL.WebApi.Models;
public sealed class AddProductRequest
{
    [Required(AllowEmptyStrings = false)]
    public string? ProductName { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Product type id must be greater then 0")]
    public int ProductTypeId { get; set; }
}
