
using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Web.Store.Actions;
public record FetchProductsAction();
public record FetchProductTypesAction();

public record FetchProductsResultAction(ICollection<Product> Products);
public record FetchProductTypesResultAction(ICollection<ProductType> ProductTypes);
