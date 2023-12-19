using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using WriteMore.API.Extensions;
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
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the next input below.
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
            
        }
    });
});



builder.Services.AddContext(builder.Configuration);
builder.Services.AddAPIServices();
builder.Services.AddAuthentication(builder.Configuration);
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
