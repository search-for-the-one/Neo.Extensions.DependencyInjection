using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public static class AddServiceMultipleInterfacesExtensions
    {
        public static void AddSingleton<I1, I2, T>(this IServiceCollection services)
            where T : class, I1, I2
            where I1 : class
            where I2 : class
        {
            services.AddSingleton<T>();
            services.AddSingleton<I1>(x => x.GetRequiredService<T>());
            services.AddSingleton<I2>(x => x.GetRequiredService<T>());
        }

        public static void AddTransient<I1, I2, T>(this IServiceCollection services)
            where T : class, I1, I2
            where I1 : class
            where I2 : class
        {
            services.AddTransient<T>();
            services.AddTransient<I1>(x => x.GetRequiredService<T>());
            services.AddTransient<I2>(x => x.GetRequiredService<T>());
        }

        public static void AddScoped<I1, I2, T>(this IServiceCollection services)
            where T : class, I1, I2
            where I1 : class
            where I2 : class
        {
            services.AddScoped<T>();
            services.AddScoped<I1>(x => x.GetRequiredService<T>());
            services.AddScoped<I2>(x => x.GetRequiredService<T>());
        }

        public static void AddSingleton<I1, I2, I3, T>(this IServiceCollection services)
            where T : class, I1, I2, I3
            where I1 : class
            where I2 : class
            where I3 : class
        {
            services.AddSingleton<T>();
            services.AddSingleton<I1>(x => x.GetRequiredService<T>());
            services.AddSingleton<I2>(x => x.GetRequiredService<T>());
            services.AddSingleton<I3>(x => x.GetRequiredService<T>());
        }

        public static void AddTransient<I1, I2, I3, T>(this IServiceCollection services)
            where T : class, I1, I2, I3
            where I1 : class
            where I2 : class
            where I3 : class
        {
            services.AddTransient<T>();
            services.AddTransient<I1>(x => x.GetRequiredService<T>());
            services.AddTransient<I2>(x => x.GetRequiredService<T>());
            services.AddTransient<I3>(x => x.GetRequiredService<T>());
        }

        public static void AddScoped<I1, I2, I3, T>(this IServiceCollection services)
            where T : class, I1, I2, I3
            where I1 : class
            where I2 : class
            where I3 : class
        {
            services.AddScoped<T>();
            services.AddScoped<I1>(x => x.GetRequiredService<T>());
            services.AddScoped<I2>(x => x.GetRequiredService<T>());
            services.AddScoped<I3>(x => x.GetRequiredService<T>());
        }

        public static void AddSingleton<I1, I2, I3, I4, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
        {
            services.AddSingleton<T>();
            services.AddSingleton<I1>(x => x.GetRequiredService<T>());
            services.AddSingleton<I2>(x => x.GetRequiredService<T>());
            services.AddSingleton<I3>(x => x.GetRequiredService<T>());
            services.AddSingleton<I4>(x => x.GetRequiredService<T>());
        }

        public static void AddTransient<I1, I2, I3, I4, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
        {
            services.AddTransient<T>();
            services.AddTransient<I1>(x => x.GetRequiredService<T>());
            services.AddTransient<I2>(x => x.GetRequiredService<T>());
            services.AddTransient<I3>(x => x.GetRequiredService<T>());
            services.AddTransient<I4>(x => x.GetRequiredService<T>());
        }

        public static void AddScoped<I1, I2, I3, I4, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
        {
            services.AddScoped<T>();
            services.AddScoped<I1>(x => x.GetRequiredService<T>());
            services.AddScoped<I2>(x => x.GetRequiredService<T>());
            services.AddScoped<I3>(x => x.GetRequiredService<T>());
            services.AddScoped<I4>(x => x.GetRequiredService<T>());
        }

        public static void AddSingleton<I1, I2, I3, I4, I5, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4, I5
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
            where I5 : class
        {
            services.AddSingleton<T>();
            services.AddSingleton<I1>(x => x.GetRequiredService<T>());
            services.AddSingleton<I2>(x => x.GetRequiredService<T>());
            services.AddSingleton<I3>(x => x.GetRequiredService<T>());
            services.AddSingleton<I4>(x => x.GetRequiredService<T>());
            services.AddSingleton<I5>(x => x.GetRequiredService<T>());
        }

        public static void AddTransient<I1, I2, I3, I4, I5, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4, I5
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
            where I5 : class
        {
            services.AddTransient<T>();
            services.AddTransient<I1>(x => x.GetRequiredService<T>());
            services.AddTransient<I2>(x => x.GetRequiredService<T>());
            services.AddTransient<I3>(x => x.GetRequiredService<T>());
            services.AddTransient<I4>(x => x.GetRequiredService<T>());
            services.AddTransient<I5>(x => x.GetRequiredService<T>());
        }

        public static void AddScoped<I1, I2, I3, I4, I5, T>(this IServiceCollection services)
            where T : class, I1, I2, I3, I4, I5
            where I1 : class
            where I2 : class
            where I3 : class
            where I4 : class
            where I5 : class
        {
            services.AddScoped<T>();
            services.AddScoped<I1>(x => x.GetRequiredService<T>());
            services.AddScoped<I2>(x => x.GetRequiredService<T>());
            services.AddScoped<I3>(x => x.GetRequiredService<T>());
            services.AddScoped<I4>(x => x.GetRequiredService<T>());
            services.AddScoped<I5>(x => x.GetRequiredService<T>());
        }
    }
}