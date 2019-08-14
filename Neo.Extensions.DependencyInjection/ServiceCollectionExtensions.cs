using System;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        // AddSingleton with provider
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddSingleton<TService1>(implementationFactory)
                .AddSingleton<TService2>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddSingleton<TService1>(implementationFactory)
                .AddSingleton<TService2, TService3, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddSingleton<TService1>(implementationFactory)
                .AddSingleton<TService2, TService3, TService4, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddSingleton<TService1>(implementationFactory)
                .AddSingleton<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        // AddTransient with provider
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddTransient<TService1>(implementationFactory)
                .AddTransient<TService2>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddTransient<TService1>(implementationFactory)
                .AddTransient<TService2, TService3, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddTransient<TService1>(implementationFactory)
                .AddTransient<TService2, TService3, TService4, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddTransient<TService1>(implementationFactory)
                .AddTransient<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        // AddScoped with provider
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddScoped<TService1>(implementationFactory)
                .AddScoped<TService2>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddScoped<TService1>(implementationFactory)
                .AddScoped<TService2, TService3, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddScoped<TService1>(implementationFactory)
                .AddScoped<TService2, TService3, TService4, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddScoped<TService1>(implementationFactory)
                .AddScoped<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        // AddSingleton with implementation
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddSingleton<TService1>(implementationInstance)
                .AddSingleton<TService2>(implementationInstance);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddSingleton<TService1>(implementationInstance)
                .AddSingleton<TService2, TService3, TImplementation>(implementationInstance);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddSingleton<TService1>(implementationInstance)
                .AddSingleton<TService2, TService3, TService4, TImplementation>(implementationInstance);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            TImplementation implementationInstance)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddSingleton<TService1>(implementationInstance)
                .AddSingleton<TService2, TService3, TService4, TService5, TImplementation>(implementationInstance);

        // AddSingleton with type
        public static IServiceCollection AddSingleton<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddSingleton<TService1, TImplementation>()
                .AddSingleton<TService2>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddSingleton<TService1, TImplementation>()
                .AddSingleton<TService2, TService3, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddSingleton<TService1, TImplementation>()
                .AddSingleton<TService2, TService3, TService4, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddSingleton<TService1, TImplementation>()
                .AddSingleton<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation) x.GetRequiredService<TService1>());

        // AddTransient with type
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddTransient<TService1, TImplementation>()
                .AddTransient<TService2>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddTransient<TService1, TImplementation>()
                .AddTransient<TService2, TService3, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddTransient<TService1, TImplementation>()
                .AddTransient<TService2, TService3, TService4, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddTransient<TService1, TImplementation>()
                .AddTransient<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        // AddScoped with type
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddScoped<TService1, TImplementation>()
                .AddScoped<TService2>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddScoped<TService1, TImplementation>()
                .AddScoped<TService2, TService3, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddScoped<TService1, TImplementation>()
                .AddScoped<TService2, TService3, TService4, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddScoped<TService1, TImplementation>()
                .AddScoped<TService2, TService3, TService4, TService5, TImplementation>(x => (TImplementation)x.GetRequiredService<TService1>());

        // AddSingletonFromFactory
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

        // AddTransientFromFactory
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

        // AddScopedFromFactory
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