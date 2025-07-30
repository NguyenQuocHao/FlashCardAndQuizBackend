using Microsoft.EntityFrameworkCore;
using FlashCardAndQuizBackend.Data;
using MySqlConnector;
using FlashCardAndQuizBackend.Repositories;
using FlashCardAndQuizBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(9, 3, 0));

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<LexicalUnitRepository>();
builder.Services.AddScoped<CardService>();

var app = builder.Build();


app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
