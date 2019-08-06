using System;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        // Singleton

        public static IServiceCollection AddSingletonFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddSingleton(type)));
            return services.AddSingleton(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2>(this IServiceCollection services, Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item1)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item2)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item3);
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3, T4>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item1)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item2)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item3)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item4);
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, (T1, T2, T3, T4, T5)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item1)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item2)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item3)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item4)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item5);
        }

        // Transient

        public static IServiceCollection AddTransientFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddTransient(type)));
            return services.AddTransient(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2>(this IServiceCollection services, Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item1)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item2)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item3);
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3, T4>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item1)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item2)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item3)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item4);
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, (T1, T2, T3, T4, T5)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item1)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item2)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item3)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item4)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item5);
        }

        // Scoped

        public static IServiceCollection AddScopedFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddScoped(type)));
            return services.AddScoped(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2>(this IServiceCollection services, Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item1)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item2)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Item3);
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3, T4>(this IServiceCollection services, Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item1)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item2)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item3)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Item4);
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, (T1, T2, T3, T4, T5)> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item1)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item2)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item3)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item4)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Item5);
        }
    }
}
