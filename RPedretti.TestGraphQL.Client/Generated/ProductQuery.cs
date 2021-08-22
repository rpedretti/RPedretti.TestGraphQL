using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
#if!GRAPHQL_GENERATOR_DISABLE_NEWTONSOFT_JSON
using Newtonsoft.Json;
#endif

namespace RPedretti.TestGraphQL.Client
{
    public class ProductQuery
    {
        public ICollection<Product?>? Products { get; set; }
        public Product? Product { get; set; }
        public ICollection<ProductType?>? ProductTypes { get; set; }
        public ProductType? ProductType { get; set; }
    }
}
