using System;

namespace Neo.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static ServiceFactory<TService, TDefault> CreateFactory<TService, TDefault>(
            this IServiceProvider serviceProvider)
            where TService : class
            where TDefault : TService
            => new ServiceFactory<TService, TDefault>(serviceProvider);
    }
}
