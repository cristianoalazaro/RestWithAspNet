using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Implementations;
using RestWithASPNET.Services;
using RestWithASPNET.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration.GetValue<string>("MySQLConnection:MySQLConnectionString");
builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
