﻿using ICEDT.API.Extensions;

namespace ICEDT.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddSwaggerAndMvc(configuration);
            services.AddAppServices();
            services.AddRepositories();
            return services;
        }


    }
}
