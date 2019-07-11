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
        public void AddServiceWithKey()
        {
            var key = "fun";
            var factory = CreateServiceFactory().AddService<FunHandler>(key);

            var funHandler = factory.WithOption(key);
            Assert.True(funHandler is FunHandler);
        }

        [Test]
        public void AddService()
        {
            var factory = CreateServiceFactory().AddService<FunHandler>();

            var funHandler = factory.WithOption(nameof(FunHandler));
            Assert.True(funHandler is FunHandler);
        }

        [Test]
        public void GetService()
        {
            var factory = CreateServiceFactory(new FactoryOptions {Handler = nameof(FunHandler)})
                .AddService<FunHandler>();

            var funHandler = factory.WithOption<FactoryOptions>(o => o.Handler);
            Assert.True(funHandler is FunHandler);
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
            var factory = CreateServiceFactory().AddService<FunHandler>();

            Assert.Throws<ArgumentException>(() => factory.WithOption("test"));
        }

        private static IServiceFactory<IHandler> CreateServiceFactory(FactoryOptions options = null)
        {
            var services = new ServiceCollection();
            services.AddSingleton<TestHandler>();
            services.AddSingleton<FunHandler>();

            services.Configure<FactoryOptions>(o => { o.Handler = options?.Handler; });

            var serviceProvider = services.BuildServiceProvider();

            return new ServiceFactory<IHandler>(serviceProvider);
        }
    }
}
