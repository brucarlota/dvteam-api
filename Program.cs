using dvteam_api.Data;
using dvteam_api.Repositories;
using dvteam_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite("Data Source=dvteam.db"));

// REPOSITORIES e SERVICES
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// CONFIGURANDO O CORS
builder.Services.AddCors(options =>
{
   options.AddPolicy("PermitirAngular", policy =>
   {
      policy.WithOrigins("http://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod(); 
   }); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// CORS
app.UseCors("PermitirAngular");

app.MapControllers();

app.Run();
