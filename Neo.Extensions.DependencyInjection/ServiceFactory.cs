using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    internal class ServiceFactory<TService> : IServiceFactory<TService>
        where TService : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public TService WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetRequiredService<TOptions>();
            var key = keySelector(options);
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

    internal class ServiceFactory<TService1, TService2> : IServiceFactory<TService1, TService2>
        where TService1 : class
        where TService2 : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public IServiceFactory<TService1, TService2> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService1, TService2> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetRequiredService<TOptions>();
            var key = keySelector(options);
            return WithOption(key);
        }

        public (TService1, TService2) WithOption(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (typeMap.TryGetValue(key, out var type))
                return ((TService1) serviceProvider.GetRequiredService(type),
                    (TService2) serviceProvider.GetRequiredService(type));

            throw new ArgumentException($"Service factory unable to resolve type for key '{key}'. Available options are [{string.Join(", ", typeMap.Keys)}].");
        }
    }

    internal class ServiceFactory<TService1, TService2, TService3> : IServiceFactory<TService1, TService2, TService3>
        where TService1 : class
        where TService2 : class
        where TService3 : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetRequiredService<TOptions>();
            var key = keySelector(options);
            return WithOption(key);
        }

        public (TService1, TService2, TService3) WithOption(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (typeMap.TryGetValue(key, out var type))
                return ((TService1) serviceProvider.GetRequiredService(type),
                    (TService2) serviceProvider.GetRequiredService(type),
                    (TService3) serviceProvider.GetRequiredService(type));

            throw new ArgumentException($"Service factory unable to resolve type for key '{key}'. Available options are [{string.Join(", ", typeMap.Keys)}].");
        }
    }

    internal class ServiceFactory<TService1, TService2, TService3, TService4> : IServiceFactory<TService1, TService2, TService3, TService4>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3, TService4
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3, TService4 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3, TService4) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetRequiredService<TOptions>();
            var key = keySelector(options);
            return WithOption(key);
        }

        public (TService1, TService2, TService3, TService4) WithOption(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (typeMap.TryGetValue(key, out var type))
                return ((TService1) serviceProvider.GetRequiredService(type),
                    (TService2) serviceProvider.GetRequiredService(type),
                    (TService3) serviceProvider.GetRequiredService(type),
                    (TService4) serviceProvider.GetRequiredService(type));

            throw new ArgumentException($"Service factory unable to resolve type for key '{key}'. Available options are [{string.Join(", ", typeMap.Keys)}].");
        }
    }

    internal class ServiceFactory<TService1, TService2, TService3, TService4, TService5> : IServiceFactory<TService1, TService2, TService3, TService4, TService5>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> typeMap = new Dictionary<string, Type>();

        public ServiceFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>(string key)
            where TDerivedResult : TService1, TService2, TService3, TService4, TService5
        {
            typeMap[key] = typeof(TDerivedResult);
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>()
            where TDerivedResult : TService1, TService2, TService3, TService4, TService5 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3, TService4, TService5) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new()
        {
            var options = serviceProvider.GetRequiredService<TOptions>();
            var key = keySelector(options);
            return WithOption(key);
        }

        public (TService1, TService2, TService3, TService4, TService5) WithOption(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (typeMap.TryGetValue(key, out var type))
                return ((TService1) serviceProvider.GetRequiredService(type),
                    (TService2) serviceProvider.GetRequiredService(type),
                    (TService3) serviceProvider.GetRequiredService(type),
                    (TService4) serviceProvider.GetRequiredService(type),
                    (TService5) serviceProvider.GetRequiredService(type));

            throw new ArgumentException($"Service factory unable to resolve type for key '{key}'. Available options are [{string.Join(", ", typeMap.Keys)}].");
        }
    }
}