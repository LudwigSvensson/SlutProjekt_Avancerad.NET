
using ClassModels;
using Microsoft.EntityFrameworkCore;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using SlutProjekt_Avancerad.NET.Services.Mapping;
using SlutProjekt_Avancerad.NET.Services.Repositories;
using System.Text.Json.Serialization;

namespace SlutProjekt_Avancerad.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfilecs));


            builder.Services.AddScoped<ICustomerIF<Customer>, CustomerRepo>();
            builder.Services.AddScoped<IAppIF<Appointment>, AppointmentRepo>();
            builder.Services.AddScoped<IAdminIF<Company>, CompanyRepo>();
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
