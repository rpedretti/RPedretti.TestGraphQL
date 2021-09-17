using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Client
{
    public sealed class QueryObject
    {
        [JsonPropertyName("operationName")]
        public string? OperationName { get; }

        [JsonPropertyName("parameters")]
        public object? Parameters { get; } = new object();

        [JsonPropertyName("query")]
        public string Query { get; set; }

    }
}
