using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Client
{
    public sealed class QueryRunner : IQueryRunner
    {
        private readonly HttpClient httpClient;

        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public QueryRunner(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> RunQuery(ProductQueryBuilder productBuilder)
        {
            var builder = new ProductQueryQueryBuilder()
                .WithProducts(productBuilder);

            var result = await Run(builder);
            return result?.Products as IEnumerable<Product> ?? new List<Product>();
        }

        public async Task<IEnumerable<ProductType>> RunQuery(ProductTypeQueryBuilder productTypeBuilder)
        {
            var builder = new ProductQueryQueryBuilder()
                .WithProductTypes(productTypeBuilder);

            var result = await Run(builder);
            return result?.ProductTypes as IEnumerable<ProductType> ?? new List<ProductType>();

        }

        public async Task<Product?> RunQuery(ProductQueryBuilder productBuilder, int productId)
        {
            var builder = new ProductQueryQueryBuilder()
                .WithProduct(productBuilder, productId);

            var result = await Run(builder);
            return result.Product;
        }

        public async Task<ProductType?> RunQuery(ProductTypeQueryBuilder productTypeBuilder, int productTypeId)
        {
            var builder = new ProductQueryQueryBuilder()
                .WithProductType(productTypeBuilder, productTypeId);

            var result = await Run(builder);
            return result.ProductType;
        }

        private async Task<ProductQuery> Run(IGraphQlQueryBuilder queryBuilder)
        {
            var query = queryBuilder.Build();

            var payload = $"{{\"operationName\": null, \"query\": \"{query}\", \"variables\": {{}}}}";

            var result = await httpClient.PostAsync("", new StringContent(payload, Encoding.UTF8, "application/json"));

            var stringResult = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<QueryResponse>(stringResult, serializerOptions);

            return response!.Data;

        }

        class QueryResponse : GraphQlResponse<ProductQuery>
        {
            public Extensions Extensions { get; set; } = new Extensions();
        }


        public class Extensions
        {
            public Tracing Tracing { get; set; } = new Tracing();
        }

        public class Tracing
        {
            public int Version { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int Duration { get; set; }
            public Parsing Parsing { get; set; } = new Parsing();
            public Validation Validation { get; set; } = new Validation();
            public Execution Execution { get; set; } = new Execution();
        }

        public class Parsing
        {
            public int StartOffset { get; set; }
            public int Duration { get; set; }
        }

        public class Validation
        {
            public int StartOffset { get; set; }
            public int Duration { get; set; }
        }

        public class Execution
        {
            public object[] Resolvers { get; set; } = Array.Empty<object>();
        }

    }
}
