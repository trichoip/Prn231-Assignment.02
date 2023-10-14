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


// https://localhost:7089/odata/Users?$top=1&$orderby=HireDate desc&$expand=Publisher,Role($top=1;$orderby=RoleId desc)
// https://localhost:7089/odata/Users?$filter=hour(HireDate) ge 18 or hour(HireDate) lt 6&$orderby=HireDate desc&$top=5&$expand=Publisher
// https://localhost:7089/odata/Publishers?$orderby=Books/$count desc&$expand=Books($top=5;$orderby=Price desc)
// https://localhost:7089/odata/Books?$expand=BookAuthors($expand=Author,Book)&$filter=PublishedDate ge 2015-01-01&$orderby=PublishedDate desc
// https://localhost:7089/odata/Authors?$expand=BookAuthors($expand=Book)&$filter=BookAuthors/$count gt 0&$orderby=AuthorId desc
