
using Lab1.Models;
using Lab1.Repositories;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>(
                options => {
                    options.UseSqlServer(@"Data Source=(local);Initial Catalog=LAB1API;Integrated Security=True;trustservercertificate = true");
                });
            builder.Services.AddScoped<IProductRepository , ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
