using System;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Tests.Mocks;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    internal class ServiceFactoryTests
    {
        [Test]
        public void AddServiceWithKey()
        {
            var key = "key";
            var factory = CreateServiceFactory().AddService<SingleInterfaceImplementor1>(key);

            var funHandler = factory.WithOption(key);
            Assert.True(funHandler is SingleInterfaceImplementor1);
        }

        [Test]
        public void AddService()
        {
            var factory = CreateServiceFactory().AddService<SingleInterfaceImplementor1>();

            var funHandler = factory.WithOption(nameof(SingleInterfaceImplementor1));
            Assert.True(funHandler is SingleInterfaceImplementor1);
        }

        [Test]
        public void GetService()
        {
            var factory = CreateServiceFactory(new FactoryOptions {Implementor = nameof(SingleInterfaceImplementor1) })
                .AddService<SingleInterfaceImplementor1>();

            var funHandler = factory.WithOption<FactoryOptions>(o => o.Implementor);
            Assert.True(funHandler is SingleInterfaceImplementor1);
        }

        [Test]
        public void GetServiceWithNull()
        {
            var factory = CreateServiceFactory();

            Assert.Throws<ArgumentNullException>(() => factory.WithOption(null));
        }

        [Test]
        public void GetServiceException()
        {
            var factory = CreateServiceFactory().AddService<SingleInterfaceImplementor1>();

            Assert.Throws<ArgumentException>(() => factory.WithOption("test"));
        }

        private static IServiceFactory<IInterface1> CreateServiceFactory(FactoryOptions options = null)
        {
            var services = new ServiceCollection();
            services.AddSingleton<SingleInterfaceImplementor1>();
            services.AddSingleton<SingleInterfaceImplementor2>();

            services.Configure<FactoryOptions>(o => { o.Implementor = options?.Implementor; });

            var serviceProvider = services.BuildServiceProvider();

            return new ServiceFactory<IInterface1>(serviceProvider);
        }

        private class FactoryOptions
        {
            public string Implementor { get; set; }
        }
    }
}