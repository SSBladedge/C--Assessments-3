global using AsmtAPI.Models;
global using AsmtAPI.Services.StudentService;
global using AsmtAPI.DTOs.StudentDTOs;
global using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using AsmtAPI.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IStudentService, StudentService>();

//below is a dependency injection
builder.Services.AddDbContext<SchooldbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStrings"));
});

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






