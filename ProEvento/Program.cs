using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProEvento;
using ProEvento.Data;
using ProEvento.Interfaces;
using ProEvento.Repositories;
using ProEvento.Services.Eventos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ProjetoMVCContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Repositories
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IPalestranteRepository, PalestranteRepository>();

//IUnitOfWork

builder.Services.AddScoped<IUnitofWork, UnitOfWork>();


//Injecao dos Services
builder.Services.AddScoped<EventoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Criacao do repositorio de imagens
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Imagens")),
    RequestPath = new PathString("/Imagens")
});

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
