using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPedretti.TestGraphQL.Server.Repository;
using GraphQL.Server;
using RPedretti.TestGraphQL.Server.Schemas;
using GraphQL.DataLoader;

namespace RPedretti.TestGraphQL.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlite(Configuration.GetConnectionString("App"))
                 .LogTo(Console.WriteLine);
            });
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ProductSchema>();

            services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddSystemTextJson()
                .AddDataLoader()
                .AddErrorInfoProvider((opt, sp) => opt.ExposeExceptionStackTrace = sp.GetRequiredService<IWebHostEnvironment>().IsDevelopment());

            services.AddCors(options =>
                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseGraphQL<ProductSchema>();
            app.UseGraphQLAltair();
            app.UseGraphQLGraphiQL();
            app.UseGraphQLPlayground();
            app.UseGraphQLVoyager();
        }
    }
}
