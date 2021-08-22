using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using RPedretti.TestGraphQL.Client;

namespace RPedretti.TestGraphQL.Consumer
{
    class Program
    {
        static async Task Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddProductsClient("https://localhost:5001/graphql");
            var sp = serviceCollection.BuildServiceProvider();
            var client = sp.GetRequiredService<IQueryRunner>();

            var builder = new ProductQueryBuilder()
                .WithProductId()
                .WithProductName()
                .WithProductType(
                    new ProductTypeQueryBuilder()
                        .WithProductTypeId()
                        .WithProductTypeName()
                );

            var builder2 = new ProductTypeQueryBuilder()
                .WithProductTypeId()
                .WithProductTypeName();

            var result = await client.RunQuery(builder);
            var result2 = await client.RunQuery(builder, 1);
            var result3 = await client.RunQuery(builder2);
            var result4 = await client.RunQuery(builder2, 1);
        }
    }
}
