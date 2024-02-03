using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Rainfall.ApiHelper.Interface;
using Rainfall.DataTransferObject;
using Rainfall.StationApi.Service;
using Rainfall.StationApiRepository;
using Rainfall.StationApiRepository.Interface;
using System.Reflection;

namespace Rainfall.StationApi
{
    /// <summary>
    /// Program 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// program startup
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            // Add services to the container.

            builder.Services.Configure<RainfallAppOptionDto>(config.GetSection("Rainfall"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddScoped<IStationRepositories, StationRepositories>();
            builder.Services.AddScoped<IStationService, StationService>();
            builder.Services.AddScoped<IDomain, Config.Domain>();

            builder.Services.AddHttpClient();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rainfall Api",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                         Name = "Sorted",
                         Url = new Uri("https://www.sorted.com")
                    },
                    Description = "An API which provides rainfall reading data"
                }); 
                // Add server information
                options.AddServer(new OpenApiServer { Url = "http://localhost:3000", Description = "Rainfall Api" });
            
                var swaggerXmlPath = $"{Path.Combine(Directory.GetCurrentDirectory(), Assembly.GetExecutingAssembly()?.GetName()?.Name ?? "Rainfall.Station")}.xml";
                // Include XML comments if available
                options.IncludeXmlComments(swaggerXmlPath);
                options.EnableAnnotations(true, true);
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
        }
    }
}
