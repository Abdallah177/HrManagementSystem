using FluentValidation;
using HrManagementSystem.Common.Data;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Middlewares;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Features.Common.CheckExists;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace HrManagementSystem.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(RequestHandlerBaseParameters<>));
            services.AddScoped(typeof(EndpointBaseParameters<>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Organization>, bool>),
                      typeof(CheckExistsQueryHandler<Organization>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Company>, bool>),
                      typeof(CheckExistsQueryHandler<Company>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Country>, bool>),
                                  typeof(CheckExistsQueryHandler<Country>));

            services.AddScoped<TransactionMiddleware>();

            services.AddFluentValidationConfig();
            services.AddMapsterConfig();
            services.AddMediatRConfig();

            return services;
        }


        public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton<IMapper>(new Mapper(mappingConfig));
            return services;
        }

        public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                    .AddFluentValidationAutoValidation();

            return services;
        }

        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            );

            return services;
        }
    }


}
