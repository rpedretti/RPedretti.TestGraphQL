using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddProductsClient("https://localhost:5001/graphql");
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IProductService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            await builder.Build().RunAsync();
        }
    }
}
