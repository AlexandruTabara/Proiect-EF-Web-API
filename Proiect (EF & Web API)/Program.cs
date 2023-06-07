using Data;
using Data.DAL;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("SqlDbConnectionString");

// Add services to the container.
builder.Services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddScoped<IDataAccessLayerService, Data.DAL.DataAccessLayerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => AddSwaggerDocumentation(o));

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

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}

