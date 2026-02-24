using CalculadoraPekus.API.Contextos;
using CalculadoraPekus.API.MiddleWare;
using CalculadoraPekus.API.Repositorys;
using CalculadoraPekus.Application.Interfaces;
using CalculadoraPekus.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CalculadoraContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();
builder.Services.AddScoped<ICalculadoraRepository, CalculadoraRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
