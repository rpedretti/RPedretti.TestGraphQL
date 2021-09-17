
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.Store;
public record ProductsState(ICollection<Product>? Products, ICollection<ProductType>? ProductTypes);
