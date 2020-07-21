using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    internal class KeyedServiceCollection<TService> : IKeyedServiceCollection<TService> where TService : class
    {
        private readonly IServiceProvider serviceProvider;
        private readonly Dictionary<string, TService> services;

        public KeyedServiceCollection(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            services = new Dictionary<string, TService>(StringComparer.OrdinalIgnoreCase);
        }

        internal IReadOnlyDictionary<string, TService> Services => services;

        public IKeyedServiceCollection<TService> AddService<TDerivedResult>() where TDerivedResult : TService
        {
            return AddService<TDerivedResult>(typeof(TDerivedResult).Name);
        }

        public IKeyedServiceCollection<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            return AddService(key, serviceProvider.GetRequiredService<TDerivedResult>());
        }

        public IKeyedServiceCollection<TService> AddService<TDerivedResult>(TDerivedResult derivedResult) where TDerivedResult : TService
        {
            return AddService(typeof(TDerivedResult).Name, derivedResult);
        }

        public IKeyedServiceCollection<TService> AddService<TDerivedResult>(string key, TDerivedResult derivedResult) where TDerivedResult : TService
        {
            services[key] = derivedResult;
            return this;
        }
    }
}