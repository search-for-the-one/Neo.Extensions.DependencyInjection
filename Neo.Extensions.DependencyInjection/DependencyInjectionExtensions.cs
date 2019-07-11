using System;

namespace Neo.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static ServiceFactory<TService, TDefault> CreateFactory<TService, TDefault>(
            this IServiceProvider serviceProvider, string key = null)
            where TService : class
            where TDefault : TService
            => new ServiceFactory<TService, TDefault>(serviceProvider, key);
    }
}
