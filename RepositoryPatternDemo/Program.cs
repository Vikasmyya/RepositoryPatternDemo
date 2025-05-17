using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Abstract.IService;
using RepositoryPatternDemo.Abstract.UnitOfWork;
using RepositoryPatternDemo.Data.Models;
using RepositoryPatternDemo.Service.Service;
using RepositoryPatternDemo.Service.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ProductDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository and UoW
builder.Services.AddScoped<IProductRepositry, ProductRepositry>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
