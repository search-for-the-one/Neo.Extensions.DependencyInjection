﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Configurations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            services.AddSingleton(implementationFactory)
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddSingleton(implementationFactory)
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddSingleton(implementationFactory)
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>)
                .AddSingleton<TService4>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddSingleton(implementationFactory)
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>)
                .AddSingleton<TService4>(Get<TImplementation>)
                .AddSingleton<TService5>(Get<TImplementation>);

        // AddTransient with provider
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddTransient(implementationFactory)
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddTransient(implementationFactory)
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddTransient(implementationFactory)
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>)
                .AddTransient<TService4>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddTransient(implementationFactory)
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>)
                .AddTransient<TService4>(Get<TImplementation>)
                .AddTransient<TService5>(Get<TImplementation>);

        // AddScoped with provider
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddScoped(implementationFactory)
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddScoped(implementationFactory)
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddScoped(implementationFactory)
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>)
                .AddScoped<TService4>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TService5, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddScoped(implementationFactory)
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>)
                .AddScoped<TService4>(Get<TImplementation>)
                .AddScoped<TService5>(Get<TImplementation>);

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
            services.AddSingleton<TImplementation>()
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddSingleton<TImplementation>()
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddSingleton<TImplementation>()
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>)
                .AddSingleton<TService4>(Get<TImplementation>);

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddSingleton<TImplementation>()
                .AddSingleton<TService1>(Get<TImplementation>)
                .AddSingleton<TService2>(Get<TImplementation>)
                .AddSingleton<TService3>(Get<TImplementation>)
                .AddSingleton<TService4>(Get<TImplementation>)
                .AddSingleton<TService5>(Get<TImplementation>);

        // AddTransient with type
        public static IServiceCollection AddTransient<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddTransient<TImplementation>()
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddTransient<TImplementation>()
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddTransient<TImplementation>()
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>)
                .AddTransient<TService4>(Get<TImplementation>);

        public static IServiceCollection AddTransient<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddTransient<TImplementation>()
                .AddTransient<TService1>(Get<TImplementation>)
                .AddTransient<TService2>(Get<TImplementation>)
                .AddTransient<TService3>(Get<TImplementation>)
                .AddTransient<TService4>(Get<TImplementation>)
                .AddTransient<TService5>(Get<TImplementation>);

        // AddScoped with type
        public static IServiceCollection AddScoped<TService1, TService2, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TImplementation : class, TService1, TService2 =>
            services.AddScoped<TImplementation>()
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TImplementation : class, TService1, TService2, TService3 =>
            services.AddScoped<TImplementation>()
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TImplementation : class, TService1, TService2, TService3, TService4 =>
            services.AddScoped<TImplementation>()
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>)
                .AddScoped<TService4>(Get<TImplementation>);

        public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TService5, TImplementation>(this IServiceCollection services)
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
            services.AddScoped<TImplementation>()
                .AddScoped<TService1>(Get<TImplementation>)
                .AddScoped<TService2>(Get<TImplementation>)
                .AddScoped<TService3>(Get<TImplementation>)
                .AddScoped<TService4>(Get<TImplementation>)
                .AddScoped<TService5>(Get<TImplementation>);

        // AddSingletonFromFactory
        public static IServiceCollection AddSingletonFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices)
            where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddSingleton(type)));
            return services.AddSingleton(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddSingletonFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, IEnumerable<T>> registerServices)
            where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddSingleton(type)));
            return services.AddSingleton(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, IEnumerable<(T1, T2)>> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item1))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item2));
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
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

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, IEnumerable<(T1, T2, T3)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item1))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item2))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item3));
        }

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
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

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, IEnumerable<(T1, T2, T3, T4)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item1))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item2))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item3))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item4));
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

        public static IServiceCollection AddSingletonFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, IEnumerable<(T1, T2, T3, T4, T5)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddSingleton(type)));

            return services
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item1))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item2))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item3))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item4))
                .AddSingleton(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item5));
        }

        // AddTransientFromFactory
        public static IServiceCollection AddTransientFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices)
            where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddTransient(type)));
            return services.AddTransient(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddTransientFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, IEnumerable<T>> registerServices)
            where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddTransient(type)));
            return services.AddTransient(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, IEnumerable<(T1, T2)>> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item1))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item2));
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
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

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, IEnumerable<(T1, T2, T3)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item1))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item2))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item3));
        }

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
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

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, IEnumerable<(T1, T2, T3, T4)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item1))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item2))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item3))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item4));
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

        public static IServiceCollection AddTransientFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, IEnumerable<(T1, T2, T3, T4, T5)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddTransient(type)));

            return services
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item1))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item2))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item3))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item4))
                .AddTransient(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item5));
        }

        // AddScopedFromFactory
        public static IServiceCollection AddScopedFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, T> registerServices) where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddScoped(type)));
            return services.AddScoped(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddScopedFromFactory<T>(this IServiceCollection services, Func<IServiceFactory<T>, IEnumerable<T>> registerServices)
            where T : class
        {
            registerServices(new ServiceFactoryRegistry<T>(type => services.AddScoped(type)));
            return services.AddScoped(p => registerServices(new ServiceFactory<T>(p)));
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, (T1, T2)> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Item1)
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Item2);
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2>, IEnumerable<(T1, T2)>> registerServices)
            where T1 : class
            where T2 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item1))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2>(p)).Select(item => item.Item2));
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, (T1, T2, T3)> registerServices)
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

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3>, IEnumerable<(T1, T2, T3)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item1))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item2))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3>(p)).Select(item => item.Item3));
        }

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, (T1, T2, T3, T4)> registerServices)
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

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3, T4>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4>, IEnumerable<(T1, T2, T3, T4)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item1))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item2))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item3))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4>(p)).Select(item => item.Item4));
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

        public static IServiceCollection AddScopedFromFactory<T1, T2, T3, T4, T5>(this IServiceCollection services,
            Func<IServiceFactory<T1, T2, T3, T4, T5>, IEnumerable<(T1, T2, T3, T4, T5)>> registerServices)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            registerServices(new ServiceFactoryRegistry<T1, T2, T3, T4, T5>(type => services.AddScoped(type)));

            return services
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item1))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item2))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item3))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item4))
                .AddScoped(p => registerServices(new ServiceFactory<T1, T2, T3, T4, T5>(p)).Select(item => item.Item5));
        }

        private static T Get<T>(IServiceProvider x) => x.GetRequiredService<T>();

        // AddConfig
        public static IServiceCollection AddConfig<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, IConfig
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            return services
                .AddSingleton(p => GetConfigSection<TConfig>(p, configuration.GetSection(typeof(TConfig).Name)))
                .AddSingleton<IConfig>(Get<TConfig>);
        }

        public static IServiceCollection AddKeyedConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, IConfig
        {
            return services.AddSingleton<IKeyedConfigs<TConfig>>(p =>
                {
                    var configs = new KeyedConfigs<TConfig>();
                    foreach (var configurationSection in configuration.GetChildren())
                        configs[configurationSection.Key] = GetConfigSection<TConfig>(p, configurationSection);

                    return configs;
                }).AddSingleton<IReadOnlyDictionary<string, TConfig>>(Get<IKeyedConfigs<TConfig>>)
                .AddSingleton<IConfig>(Get<IKeyedConfigs<TConfig>>);
        }

        private static readonly string EmptyStringJson = JsonConvert.SerializeObject(string.Empty);
        
        private static TConfig GetConfigSection<TConfig>(IServiceProvider p, IConfigurationSection section)
            where TConfig : IConfig
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            if (section is INeoConfigurationSection neoConfigurationSection)
            {
                var json = neoConfigurationSection.ToJson();
                return string.IsNullOrEmpty(json) || json == EmptyStringJson
                    ? (TConfig) ActivatorUtilities.CreateInstance(p, typeof(TConfig))
                    : JsonConvert.DeserializeObject<TConfig>(json, new NeoCustomCreationConverter(p)) ??
                      (TConfig) ActivatorUtilities.CreateInstance(p, typeof(TConfig));
            }

            var config = (TConfig) ActivatorUtilities.CreateInstance(p, typeof(TConfig));
            section.Bind(config);
            return config;
        }

        private class NeoCustomCreationConverter : CustomCreationConverter<object>
        {
            private readonly IServiceProvider serviceProvider;

            public NeoCustomCreationConverter(IServiceProvider serviceProvider)
            {
                this.serviceProvider = serviceProvider;
            }

            public override object Create(Type objectType)
            {
                return ActivatorUtilities.CreateInstance(serviceProvider, objectType);
            }

            public override bool CanConvert(Type objectType)
            {
                return !objectType.Namespace.StartsWith("System") && objectType.IsClass;
            }
        }

        // AddKeyed
        public static IServiceCollection AddKeyed<T>(this IServiceCollection services, string section) =>
            services.AddSingleton(sp => sp.GetRequiredService<IKeyedServiceProvider>()
                .GetRequiredService<T>(section));

        public static IServiceCollection AddSingletonKeyedServices<TService>(this IServiceCollection services,
            Func<IKeyedServiceCollection<TService>, IKeyedServiceCollection<TService>> registerServices) where TService : class
        {
            return services.AddSingleton(p => ((KeyedServiceCollection<TService>) registerServices(new KeyedServiceCollection<TService>(p))).Services);
        }

        public static IServiceCollection AddScopedKeyedServices<TService>(this IServiceCollection services,
            Func<IKeyedServiceCollection<TService>, IKeyedServiceCollection<TService>> registerServices) where TService : class
        {
            return services.AddScoped(p => ((KeyedServiceCollection<TService>) registerServices(new KeyedServiceCollection<TService>(p))).Services);
        }

        public static IServiceCollection AddTransientKeyedServices<TService>(this IServiceCollection services,
            Func<IKeyedServiceCollection<TService>, IKeyedServiceCollection<TService>> registerServices) where TService : class
        {
            return services.AddTransient(p => ((KeyedServiceCollection<TService>) registerServices(new KeyedServiceCollection<TService>(p))).Services);
        }
    }
}