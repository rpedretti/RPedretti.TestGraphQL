using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace RPedretti.TestGraphQL.Client
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsClient(this IServiceCollection serviceCollection, string baseUrl)
        {
            serviceCollection.AddHttpClient<IQueryRunner, QueryRunner>(c => {
                c.BaseAddress = new Uri(baseUrl);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            return serviceCollection;
        }
    }
}
