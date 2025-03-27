using System.Reflection;
using webapi.event_.Contexts;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Configuração do banco de dados
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependência dos repositórios
builder.Services.AddScoped<ITiposEventosRepository, TiposEventosRepository>();
builder.Services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<IPresencasEventosRepository, PresencasEventosRepository>();
builder.Services.AddScoped<IEventosRepository, EventosRepository>();
builder.Services.AddScoped<IComentariosEventosRepository, ComentariosEventosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuariosRepository>();


//Adiciona o serviço de Controllers
builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();
app.Run();

app.Run();