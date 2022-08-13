using Microsoft.EntityFrameworkCore;
using Serilog;
using Staycation.Api.Data;
using Staycation.Api.Data.Access;
using Staycation.Api.Data.Services;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//var logger = new LoggerConfiguration().WriteTo.File("Logs/log.txt",rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AccommodationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString")));

builder.Services.AddTransient<AccommodationsService>();
builder.Services.AddTransient<LocationsService>();
builder.Services.AddTransient<ReservationsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

DbInitializer.SeedDb(app);