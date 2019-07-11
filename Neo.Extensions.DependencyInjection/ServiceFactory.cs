using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Neo.Extensions.DependencyInjection
{
    internal class ServiceFactory<TService> : IServiceFactory<TService> where TService : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService
        {
            return AddService<TDerivedResult>(typeof(TDerivedResult).Name);
        }

        public TService WithOption<TOptions>(Func<TOptions, string> serviceSelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetService<IOptions<TOptions>>().Value;
            var key = serviceSelector(options);
            return WithOption(key);
        }

        public TService WithOption(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (typeMap.TryGetValue(key, out var type))
                return (TService) serviceProvider.GetRequiredService(type);

            throw new ArgumentException($"Service factory unable to resolve type for key '{key}'. Available options are [{string.Join(", ", typeMap.Keys)}].");
        }
    }
}
