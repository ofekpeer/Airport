
using FlightControl.Models.Models;
using FlightControl.Servies.Repositories;
using Microsoft.EntityFrameworkCore;
using PlaneControl.Logic;
using PlaneControl.Logic.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddScoped<IRepository<Flight>, PlaneReposiroty>();
builder.Services.AddScoped<IRepository<Logger>, LoggerRepository>();
builder.Services.AddScoped<IRepository<Terminal>, TerminalRepository>();
builder.Services.AddSingleton<Airterminal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();