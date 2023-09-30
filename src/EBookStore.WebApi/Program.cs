using EBookStore.Application;
using EBookStore.Domain.Entities;
using EBookStore.Infrastructure;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
                .AddOData(options => options.Select().Filter()
                    .OrderBy().Count().Expand().SetMaxTop(100)
                    .AddRouteComponents("odata", GetEdmModel()));

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
    modelBuilder.EntitySet<Author>("Authors");
    modelBuilder.EntitySet<Book>("Books");
    modelBuilder.EntitySet<User>("Users");
    modelBuilder.EntitySet<Publisher>("Publishers");
    return modelBuilder.GetEdmModel();
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseInitialiseDatabaseAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
