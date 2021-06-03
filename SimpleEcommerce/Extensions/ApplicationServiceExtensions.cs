using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleEcommerce.Infrastructure.Contracts;
using SimpleEcommerce.Infrastructure.Models;
using SimpleEcommerce.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Extensions
{
    public static class  ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbConfig>(configuration);
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IDbClientService, DbClientService>();
            services.AddSingleton<IProductService, ProductService>();
            return services;
        }
    }
}
