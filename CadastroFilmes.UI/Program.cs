using AutoMapper;
using CadastroFilmes.Aplication.AMapper;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Aplication.Services;
using CadastroFilmes.Domain.Handlers;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Infra.Context;
using CadastroFilmes.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connetions = builder.Configuration.GetConnectionString("DefaultConnetion"); 

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CadastroFilmesDbContext>(options=>options.UseSqlite(connetions));

builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>(); 
builder.Services.AddScoped<IRealizadorRepository, RealizadorRepository>();

builder.Services.AddScoped<CommandFilmeHandler>(); 
builder.Services.AddScoped<QueryFilmeHandler>();
builder.Services.AddScoped<CommandRealizadorHandler>();
builder.Services.AddScoped<QueryRealizadorHandler>();

builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IRealizadorService, RealizadorService>();

builder.Services.AddAutoMapper(typeof(MapperDTOProfile)); 



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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
