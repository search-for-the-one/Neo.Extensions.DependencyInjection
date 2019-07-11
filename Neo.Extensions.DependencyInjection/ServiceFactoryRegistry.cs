using System;
using System.Collections.Generic;

namespace Neo.Extensions.DependencyInjection
{
    internal class ServiceFactoryRegistry<TService> : IServiceFactory<TService> where TService : class
    {
        private readonly Action<Type> addService;
        private readonly ISet<Type> types = new HashSet<Type>();

        public ServiceFactoryRegistry(Action<Type> addService)
        {
            this.addService = addService;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            types.Add(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService
        {
            return AddService<TDerivedResult>(typeof(TDerivedResult).Name);
        }

        public TService WithOption<TOptions>(Func<TOptions, string> serviceSelector) where TOptions : class, new()
        {
            AddServices();
            return null;
        }

        public TService WithOption(string key)
        {
            AddServices();
            return null;
        }

        private void AddServices()
        {
            foreach (var service in types)
            {
                addService(service);
            }
        }
    }
}