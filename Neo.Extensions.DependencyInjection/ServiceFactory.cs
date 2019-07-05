using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Neo.Extensions.DependencyInjection
{
    public class ServiceFactory<TService, TDefault> where TService : class where TDefault : TService
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>
            {{typeof(TDefault).Name, typeof(TDefault)}};

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ServiceFactory<TService, TDefault> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public ServiceFactory<TService, TDefault> AddService<TDerivedResult>() where TDerivedResult : TService
        {
            return AddService<TDerivedResult>(typeof(TDerivedResult).Name);
        }

        public TService GetService<TOptions>(Func<TOptions, string> serviceSelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetService<IOptions<TOptions>>().Value;
            var key = serviceSelector(options);
            return GetService(key);
        }

        public TService GetService(string key)
        {
            if (string.IsNullOrEmpty(key))
                return (TService)serviceProvider.GetRequiredService(typeof(TDefault));

            if (typeMap.TryGetValue(key, out var type))
                return (TService)serviceProvider.GetRequiredService(type);

            throw new ArgumentException($"Unable to resolve type for key {key}.");
        }
    }
}
