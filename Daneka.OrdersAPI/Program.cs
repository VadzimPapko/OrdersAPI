//Swagger, JSON, static collection (N-layer arch)

// Get All Orders
// Get Order By ID
// Delete Order By ID
// Create Order By ID
// Update Order By ID

//Order entity
// Id (Guid, autogenerated)
// Total (decimal)
// BuyerId (Guid)

// List ProductItems []
//  Product Name
//  Product Price
//  Quantity
//  Total Price 

using Daneka.OrdersAPI.Core.Entities;
using Daneka.OrdersAPI.Core.Interfaces;
using Daneka.OrdersAPI.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<Product>, StaticProductRepository>();
builder.Services.AddScoped<IRepository<Order>, StaticOrdersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/orders", IResult (IRepository<Order> orders) => TypedResults.Ok(orders))
    .Produces(400)
    .Produces<Order>()
    .WithName("GetAllOrders")
    .WithOpenApi();

app.Run();
