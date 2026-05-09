using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Isso avisa à sua API: "Ei, quando alguém precisar mexer no banco, use o AppDbContext com as configurações que coloquei no appsettings!"

// Registro dos serviços para a API
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
