
using HrManagementSystem.Common;
using HrManagementSystem.Common.Middlewares;
using HrManagementSystem.Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<TransactionMiddleware>();

            builder.Services.AddScoped(typeof(RequestHandlerBaseParameters<>));
            builder.Services.AddScoped(typeof(EndpointBaseParameters<>));
            var app = builder.Build();

            app.UseMiddleware<TransactionMiddleware>();

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
