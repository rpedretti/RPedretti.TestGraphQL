using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RPedretti.TestGraphQL.Web.Components.Cms;
using RPedretti.TestGraphQL.Web.Configuration;
using RPedretti.TestGraphQL.Web.Services;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var currentAssembly = typeof(Program).Assembly;
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.RootComponents.Add<App>("#app");

            var rootConfiguration = builder.Configuration.Get<RootConfiguration>();
            builder.Services.AddSingleton(rootConfiguration.WebApiConfiguration);
            builder.Services.AddHttpClient<IWebApiClient, WebApiClient>((sp, c) =>
            {
                c.BaseAddress = new Uri(sp.GetRequiredService<WebApiConfiguration>().BaseUrl);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            builder.Services.AddScoped<ICmsSelector, CmsSelector>();
            builder.Services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(f => f
                    .InExactNamespaceOf<IProductService>()
                    .Where(x => x.Name != "WebApiClient")
                )
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            builder.Services.AddFluxor(options => options
                .ScanAssemblies(currentAssembly)
                .UseReduxDevTools());

            await builder.Build().RunAsync();
        }
    }
}
