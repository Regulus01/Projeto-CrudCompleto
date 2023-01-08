using System.Data.Common;
using System.Reflection;
using AutoMapper;
using Infra.Pessoa.Common;
using Infra.Pessoa.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using Pessoa.Application.AutoMapper;
using Pessoa.Domain.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbConnection
var connectionString = builder.Configuration.GetConnectionString("App");
DbConnection dbConnection = new NpgsqlConnection(connectionString);
builder.Services.AddDbContext<PessoaContext>(opt =>
{
    opt.UseNpgsql(dbConnection, assembly =>
        assembly.MigrationsAssembly(typeof(PessoaContext).Assembly.FullName));
});


PessoaDependecyInjection.Register(builder.Services);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Crud Completo",
        Description = "Crud completo"

    });
  
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    
});

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();