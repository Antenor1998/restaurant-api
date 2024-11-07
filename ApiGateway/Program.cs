using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Ocelot y Consul
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Agrega los servicios de Ocelot y Consul
builder.Services.AddOcelot().AddConsul();

// Configuración de Swagger para el API Gateway
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
});

var app = builder.Build();

// Configuración de Swagger y Ocelot en el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway V1");
});

app.UseOcelot().Wait();

app.Run();
