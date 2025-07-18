using ICEDT.API.Repositories.Implementation;
using ICEDT.API.Repositories.Interfaces;

namespace ICEDT.API.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            services.AddScoped<IProgressRepository, ProgressRepository>();
            return services;
        }
    }
}
