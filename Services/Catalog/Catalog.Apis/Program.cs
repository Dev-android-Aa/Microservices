
#region DI

using Catalog.Apis.Data;
using Catalog.Apis.Repository;
using Catalog.Apis.Shared;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});

//interface + class
builder.Services.Configure<DatabaseSetting>(op => builder.Configuration.GetSection("DatabaseSetting").Bind(op));//registration ma classe databasesetting
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();//one instance
builder.Services.AddScoped<IProductRepository, ProductRepository>();//shared object injection

#endregion

#region Middleware

var app = builder.Build();

// Configure the HTTP request pipeline.
var env = app.Environment;
// swagger
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
}


app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion



