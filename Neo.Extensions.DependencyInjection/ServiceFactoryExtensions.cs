using System;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public static class ServiceFactoryExtensions
    {
        public static IServiceCollection AddSingletonFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddSingleton(type)));
            return services.AddSingleton(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddTransientFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddTransient(type)));
            return services.AddTransient(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddScopedFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddScoped(type)));
            return services.AddScoped(p => registerServices(new ServiceFactory<T>(p)));
        }
    }
}
