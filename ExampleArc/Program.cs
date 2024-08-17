using ExamleArc.Db;
using ExamleArc.Db.Models;
using ExamleArc.Db.Repo;
using ExampleArc.Application.Services;
using ExampleArc.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StudenDbContext");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExampleArcDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });
builder.Services.AddScoped<IStudentService,StudentService>();
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
