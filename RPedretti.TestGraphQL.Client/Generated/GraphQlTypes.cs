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
    public static class GraphQlTypes
    {
        public const string Boolean = "Boolean";
        public const string Int = "Int";
        public const string String = "String";

        public const string Product = "Product";
        public const string ProductQuery = "ProductQuery";
        public const string ProductType = "ProductType";

        public static readonly IReadOnlyDictionary<Type, string> ReverseMapping =
            new Dictionary<Type, string>
            {
                { typeof(int), "Int" },
                { typeof(string), "String" }
            };
}
}
