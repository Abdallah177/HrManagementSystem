using FluentValidation;
using HrManagementSystem.Common.Data;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Middlewares;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
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

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Department>, bool>),
                                  typeof(CheckExistsQueryHandler<Department>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<City>, bool>),
                                  typeof(CheckExistsQueryHandler<City>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Company>, bool>),
                                  typeof(CheckExistsQueryHandler<Company>));

            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<State>, bool>), typeof(CheckExistsQueryHandler<State>));
            services.AddTransient(typeof(IRequestHandler<CheckExistsQuery<Branch>, bool>), typeof(CheckExistsQueryHandler<Branch>));

            services.AddTransient<IRequestHandler<ConfigurationScopeOrchestrator<ShiftScope, Shift>, RequestResult<bool>>, ConfigurationScopeOrchestratorHandler<ShiftScope, Shift>>();



            services.AddScoped<TransactionMiddleware>();

            services.AddFluentValidationConfig();
            services.AddMapsterConfig();
            services.AddMediatRConfig();
            
            //services.AddTransient<RequestHandlerBaseParameters>(sp => new RequestHandlerBaseParameters(sp.GetRequiredService<IMediator>()));



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
