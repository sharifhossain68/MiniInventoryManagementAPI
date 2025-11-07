using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.AutoMapper;
using MiniInventory.Application.Interface;
using MiniInventory.Application.Service;
using MiniInventory.Infrastructure.Data;
using MiniInventory.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers().AddFluentValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
//builder.Services.AddDbContext<MiniInventoryDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniInventoryConnection")));
//Db Context
var connectionString = builder.Configuration.GetConnectionString("MiniInventoryConnection");
builder.Services.AddDbContext<MiniInventoryDbContext>(options =>
    options.UseSqlServer(connectionString));
// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


// Application services
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
//builder.Services.AddScoped<OrderService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

//builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
