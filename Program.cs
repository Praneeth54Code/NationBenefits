using Microsoft.EntityFrameworkCore;
using NationBenefits.Context;
using NationBenefits.Decorators;
using NationBenefits.Interfaces;
using NationBenefits.Repositories;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{Level:u3}] {Message:lj}{NewLine}{Exception}"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
//builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();


builder.Services.AddRouting();
builder.Services.AddLogging();

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<IProductRepository>(provider=>

     new LoggingDecorator(
         
         provider.GetRequiredService<ProductRepository>(),
         provider.GetRequiredService<ILogger<LoggingDecorator>>()
         
         ));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(app =>
{
    app.MapControllers();
});




app.Run();

