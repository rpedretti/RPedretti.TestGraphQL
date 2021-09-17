using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPedretti.TestGraphQL.Client;
using RPedretti.TestGraphQL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProductsClient("https://localhost:5001/graphql");
builder.Services.Scan(scan => scan
    .FromAssemblyOf<IProductService>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TestGraphQL WebApi", Version = "v1" });
});
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
