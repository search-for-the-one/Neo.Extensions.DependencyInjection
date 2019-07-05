using System;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Tests.Handlers;
using Neo.Extensions.DependencyInjection.Tests.Options;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    internal class ServiceFactoryTests
    {
        [Test]
        public void NewFactory()
        {
            var factory = CreateServiceFactory();

            var defaultHandler = factory.GetService(null);
            Assert.True(defaultHandler is TestHandler);
        }

        [Test]
        public void AddServiceWithKey()
        {
            var key = "fun";
            var factory = CreateServiceFactory().AddService<FunHandler>(key);

            var funHandler = factory.GetService(key);
            Assert.True(funHandler is FunHandler);
        }

        [Test]
        public void AddService()
        {
            var factory = CreateServiceFactory().AddService<FunHandler>();

            var funHandler = factory.GetService(nameof(FunHandler));
            Assert.True(funHandler is FunHandler);
        }

        [Test]
        public void GetService()
        {
            var factory = CreateServiceFactory(new FactoryOptions {Handler = nameof(FunHandler)})
                .AddService<FunHandler>();

            var funHandler = factory.GetService<FactoryOptions>(o => o.Handler);
            Assert.True(funHandler is FunHandler);
        }

        [Test]
        public void GetServiceException()
        {
            var factory = CreateServiceFactory().AddService<FunHandler>();

            Assert.Throws<ArgumentException>(() => factory.GetService("test"));
        }

        private ServiceFactory<IHandler, TestHandler> CreateServiceFactory(FactoryOptions options = null)
        {
            var services = new ServiceCollection();
            services.AddSingleton<TestHandler>();
            services.AddSingleton<FunHandler>();

            services.Configure<FactoryOptions>(o => { o.Handler = options?.Handler; });

            var serviceProvider = services.BuildServiceProvider();

            return new ServiceFactory<IHandler, TestHandler>(serviceProvider);
        }
    }
}
