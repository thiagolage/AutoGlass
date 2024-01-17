global using AutoGlass.Models;
using AutoGlass.API.Database;
using AutoGlass.API.DTOs;
using AutoGlass.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AutoGlassContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AutoGlass")));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddAutoMapper(typeof(ProdutoDTO));

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
