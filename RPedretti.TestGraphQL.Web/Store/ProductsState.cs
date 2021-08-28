
using RPedretti.TestGraphQL.Types;

namespace RPedretti.TestGraphQL.Web.Store;
public record ProductsState(ICollection<Product> Products, ICollection<ProductType> ProductTypes);
