using Business;
using DataAccess;
using Entities;
using Entities.EntitiesValidations;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Inyeccion de dependencias
builder.Services.AddDbContext<InventoryContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"))
);
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<IInputOutputBusiness, InputOutputBusiness>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<IStorageBusiness, StorageBusiness>();
builder.Services.AddScoped<IWarehouseBusiness, WarehouseBusiness>();

// Inyeccion de dependencias para validadores
builder.Services.AddScoped<IValidator<CategoryEntity>, CategoryValidator>();
builder.Services.AddScoped<IValidator<ProductEntity>, ProductValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
