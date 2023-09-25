using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Repositories;
using Northwind.WebApi.Services;

namespace Northwind.WebApi;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddScoped<INorthwindService, NorthwindService>();
        builder.Services.AddScoped<INorthwindRepository, NorthwindRepository>();

        builder.Services.AddCors(options => options
                            .AddDefaultPolicy(policyConfig => policyConfig
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowAnyOrigin()));

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseCors();

        app.Run();
    }
}