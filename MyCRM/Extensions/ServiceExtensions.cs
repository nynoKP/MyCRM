using MyCRM.Interface.Repository;
using MyCRM.Interface.Service;
using MyCRM.Repository;
using MyCRM.Services;

namespace MyCRM.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
