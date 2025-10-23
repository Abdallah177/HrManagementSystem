using FluentValidation;
using HrManagementSystem.Common.Authntication.Jwt;
using HrManagementSystem.Common.Data;
using HrManagementSystem.Common.Middlewares;
using HrManagementSystem.Common.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace HrManagementSystem.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(RequestHandlerBaseParameters<>));

            services.AddScoped(typeof(EndpointBaseParameters<>));

            services.AddScoped<TransactionMiddleware>();


            services.AddAuthConfig(config);
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
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddFluentValidationAutoValidation();
            return services;
        }

        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddOptions<JwtSettings>()
                .BindConfiguration(JwtSettings.SectionName);


            var jwtOptions = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                    };
                });
            return services;
        }
    }

}
