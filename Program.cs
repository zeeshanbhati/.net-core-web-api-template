using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFTemplate.Data;
using EFTemplate.Controllers;
using EFTemplate.Services;
using EFTemplate.Repository;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EFTemplateContext>(options =>
    options.UseMySQL("server=localhost;port=3307;database=test;user=root;password=root"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Services
builder.Services.AddScoped<StationService, StationService>();


// Add repositories
builder.Services.AddTransient<StationRepository, StationRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                // Handle the exception
                if (app.Environment.IsDevelopment())
                {
                    // Include the exception message and stack trace in the response (for development purposes)
                    await context.Response.WriteAsync(error.Error.ToString());
                }
                else
                {
                    // Only include the exception message in the response (for production purposes)
                    await context.Response.WriteAsync("An error occurred. Please try again later.");
                }
            }
        });
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
