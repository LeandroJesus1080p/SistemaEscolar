using Escola.Models.Entities;
using Escola.Services.Repositories.Alunos;
using Escola.Services.Repositories.Contatos;
using Escola.Services.Repositories.CreateTokens;
using Escola.Services.Repositories.Disciplinas;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DatabaseContext
ContextDatabase(builder);
//AddScoped
ConfigureService(builder);
// define política padrão CORS
AddPolicyCors(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ContextDatabase(WebApplicationBuilder builder)
{
    builder.Services.AddDbContextPool<DatabaseContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b
            .MigrationsAssembly("Escola.Api")
            .MigrationsHistoryTable("escola"));
    });
}

void ConfigureService(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IAlunoService, AlunoService>();
    builder.Services.AddScoped<IContatoService, ContatoService>();
    builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
    builder.Services.AddScoped<TokenService>();
}

void AddPolicyCors(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder => { builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); });
    });
}