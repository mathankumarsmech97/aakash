using Microsoft.AspNetCore.Hosting;
using productService;
using Sample.Shopping.Store.productStore;
using ShoppingCart.Service;
using ShoppingCart.Store;
using static ShoppingCart.Store.IReturnStore;
using static ShoppingCart.Store.ProductStoreInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStore, ProductStore>();

builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockStore, StockStore>();


builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseStore, PurchaseStore>();

builder.Services.AddScoped<IReturnService, ReturnService>();
builder.Services.AddScoped<IReturnStore, _ReturnStore>();


//IServiceCollection serviceCollection1 = builder.Services.AddScoped<IProductStore, ProductStore>();
//IServiceCollection serviceCollection = builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
