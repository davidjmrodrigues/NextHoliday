using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NextHoliday.API.Endpoints;
using NextHoliday.API.Middleware;
using NextHoliday.Application;
using NextHoliday.Application.Common;
using NextHoliday.Infrastructure.Persistence;
using Scalar.AspNetCore;


// BUILDER
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Version = "v0.1.0";
        document.Info.Title = "NextHoliday API";
        document.Info.Description = "Holiday recomendation API.";
        return Task.CompletedTask;
    });
});


// APP
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();



// ENDPOINTS
var versionedGroup = app.MapGroup("api/v1");    

var endpointTypes = typeof(Program).Assembly.GetTypes()
    .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

foreach (var type in endpointTypes)
{
    var endpoint = (IEndpoint) Activator.CreateInstance(type)!;
    endpoint.MapEndpoint(versionedGroup);
}

app.Run();
