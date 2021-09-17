
using System.ComponentModel.DataAnnotations;

namespace RPedretti.TestGraphQL.WebApi.Models;
public sealed class GetProductRequestModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Product Id must be greater then 0")]
    public int ProductId { get; set; }

    public bool WithProductType { get; set; }
}
