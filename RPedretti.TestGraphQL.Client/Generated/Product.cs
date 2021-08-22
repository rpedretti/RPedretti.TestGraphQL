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
    public class Product
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public ProductType? ProductType { get; set; }
    }
}
