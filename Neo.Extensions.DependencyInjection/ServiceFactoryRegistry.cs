using System;
using System.Collections.Generic;
using System.Linq;

namespace Neo.Extensions.DependencyInjection
{
    internal class ServiceFactoryRegistry<TService> : IServiceFactory<TService>
        where TService : class
    {
        private readonly Action<Type> addService;

        public ServiceFactoryRegistry(Action<Type> addService) => this.addService = addService;

        public IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService
        {
            addService(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public TService WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class => null;

        public TService WithOption(string key) => null;

        public IEnumerable<TService> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class => null;

        public IEnumerable<TService> WithOption(IEnumerable<string> keys) => null;
    }

    internal class ServiceFactoryRegistry<TService1, TService2> : IServiceFactory<TService1, TService2>
        where TService1 : class
        where TService2 : class
    {
        private readonly Action<Type> addService;

        public ServiceFactoryRegistry(Action<Type> addService) => this.addService = addService;

        public IServiceFactory<TService1, TService2> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2
        {
            addService(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService1, TService2> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class => (null, null);

        public (TService1, TService2) WithOption(string key) => (null, null);

        public IEnumerable<(TService1, TService2)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class => Enumerable.Empty<(TService1, TService2)>();

        public IEnumerable<(TService1, TService2)> WithOption(IEnumerable<string> keys) => Enumerable.Empty<(TService1, TService2)>();
    }

    internal class ServiceFactoryRegistry<TService1, TService2, TService3> : IServiceFactory<TService1, TService2, TService3>
        where TService1 : class
        where TService2 : class
        where TService3 : class
    {
        private readonly Action<Type> addService;

        public ServiceFactoryRegistry(Action<Type> addService) => this.addService = addService;

        public IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3
        {
            addService(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class => (null, null, null);

        public (TService1, TService2, TService3) WithOption(string key) => (null, null, null);

        public IEnumerable<(TService1, TService2, TService3)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class => Enumerable.Empty<(TService1, TService2, TService3)>();

        public IEnumerable<(TService1, TService2, TService3)> WithOption(IEnumerable<string> keys) => Enumerable.Empty<(TService1, TService2, TService3)>();
    }

    internal class ServiceFactoryRegistry<TService1, TService2, TService3, TService4> : IServiceFactory<TService1, TService2, TService3, TService4>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
    {
        private readonly Action<Type> addService;

        public ServiceFactoryRegistry(Action<Type> addService) => this.addService = addService;

        public IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3, TService4
        {
            addService(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3, TService4 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3, TService4) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class => (null, null, null, null);

        public (TService1, TService2, TService3, TService4) WithOption(string key) => (null, null, null, null);

        public IEnumerable<(TService1, TService2, TService3, TService4)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class => Enumerable.Empty<(TService1, TService2, TService3, TService4)>();

        public IEnumerable<(TService1, TService2, TService3, TService4)> WithOption(IEnumerable<string> keys) => Enumerable.Empty<(TService1, TService2, TService3, TService4)>();
    }

    internal class ServiceFactoryRegistry<TService1, TService2, TService3, TService4, TService5> : IServiceFactory<TService1, TService2, TService3, TService4, TService5>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
    {
        private readonly Action<Type> addService;

        public ServiceFactoryRegistry(Action<Type> addService) => this.addService = addService;

        public IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>(string key)
            where TDerivedResult : TService1, TService2, TService3, TService4, TService5
        {
            addService(typeof(TDerivedResult));
            return this;
        }

        public IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3, TService4
            , TService5 =>
            AddService<TDerivedResult>(typeof(TDerivedResult).Name);

        public (TService1, TService2, TService3, TService4, TService5) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class => (null, null, null, null, null);

        public (TService1, TService2, TService3, TService4, TService5) WithOption(string key) => (null, null, null, null, null);

        public IEnumerable<(TService1, TService2, TService3, TService4, TService5)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class => Enumerable.Empty<(TService1, TService2, TService3, TService4, TService5)>();

        public IEnumerable<(TService1, TService2, TService3, TService4, TService5)> WithOption(IEnumerable<string> keys) => Enumerable.Empty<(TService1, TService2, TService3, TService4, TService5)>();
    }
}