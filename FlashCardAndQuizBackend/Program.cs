using Microsoft.EntityFrameworkCore;
using FlashCardAndQuizBackend.Data;
using Serilog;
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
builder.Services.AddScoped<MeaningRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<GeneralRepository>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<MeaningService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<GeneralService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(@$"{AppDomain.CurrentDomain.BaseDirectory}\logs\log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();

Log.CloseAndFlush();