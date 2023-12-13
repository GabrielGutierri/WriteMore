using Microsoft.AspNetCore.Identity;
using WriteMore.Application.Interfaces.Services;
using WriteMore.Data.Context;
using WriteMore.Data.Repository;
using WriteMore.Domain.Interfaces.Repository;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;
using WriteMore.Domain.Services;
using WriteMore.Identity.Data;
using WriteMore.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<WriteMoreContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSqlServer<IdentityDataContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddScoped<IService<Book>, BookService>();
builder.Services.AddScoped<IService<Movie>, MovieService>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();


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
