using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Repositories;

namespace Bootstrapper
{
    public static class DependencyInjectionBootstrapper
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDeviceDetailRepository, DeviceDetailRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
            services.AddScoped<IPinRepository, PinRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
