using RPedretti.TestGraphQL.Types;
using RPedretti.TestGraphQL.Web.Models;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.Store.Actions;
public record ClearProductsAction();
public record FetchProductsAction();
public record FetchProductTypesAction();

public record FetchProductsResultAction(ICollection<Product> Products);
public record FetchProductTypesResultAction(ICollection<ProductType> ProductTypes);

public record AddProductAction(AddProductModel Model);
public record AddProductActionResult(Product Product);
