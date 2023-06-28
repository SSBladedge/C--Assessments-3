using AsmtAPI.Data;
using Microsoft.EntityFrameworkCore;
using AsmtAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchooldbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
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


// foreach (Student student in students)
// {
//     Console.WriteLine("-----------------------------------------");
//     Console.WriteLine($"Id:   {student.ID}");
//     Console.WriteLine($"Name:   {student.FirstName} {student.LastName}");
//     Console.WriteLine($"dob:   {student.DateOfBirth}");
//     Console.WriteLine($"Address:   {student.Address}");
//     Console.WriteLine($"Grade:   {student.Grade}");
//     Console.WriteLine("-----------------------------------------");
// }
