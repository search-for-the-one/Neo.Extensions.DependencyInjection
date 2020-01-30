using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    public class ServiceFactoryTests
    {
        [Test]
        public void AddServiceWithKey()
        {
            const string key = "key";
            var factory = CreateServiceFactory().AddService<Implementation1>(key);

            var funHandler = factory.WithOption(key);
            Assert.True(funHandler is Implementation1);
        }

        [Test]
        public void AddService()
        {
            var factory = CreateServiceFactory().AddService<Implementation1>();

            var funHandler = factory.WithOption(nameof(Implementation1));
            Assert.True(funHandler is Implementation1);
        }

        [Test]
        public void AddServices()
        {
            var factory = CreateServiceFactory().AddService<Implementation1>().AddService<Implementation2>();

            var funHandlers = factory.WithOption(new [] {nameof(Implementation1), nameof(Implementation2)}).ToList();
            Assert.AreEqual(2, funHandlers.Count);
            CollectionAssert.AreEqual(new []{typeof(Implementation1), typeof(Implementation2)}, funHandlers.Select(f => f.GetType()));
        }

        [Test]
        public void GetService()
        {
            var factory = CreateServiceFactory(new FactoryOptions {Implementor = nameof(Implementation1)})
                .AddService<Implementation1>();

            var funHandler = factory.WithOption<FactoryOptions>(o => o.Implementor);
            Assert.True(funHandler is Implementation1);
        }

        [Test]
        public void GetServices()
        {
            var factory = CreateServiceFactory(new FactoryOptions {Implementors = new [] {nameof(Implementation1), nameof(Implementation2)}})
                .AddService<Implementation1>().AddService<Implementation2>();

            var funHandlers = factory.WithOption<FactoryOptions>(o => o.Implementors).ToList();
            Assert.AreEqual(2, funHandlers.Count);
            CollectionAssert.AreEqual(new []{typeof(Implementation1), typeof(Implementation2)}, funHandlers.Select(f => f.GetType()));
        }

        [Test]
        public void GetServiceWithNull()
        {
            var factory = CreateServiceFactory();

            Assert.Throws<ArgumentNullException>(() => factory.WithOption((string) null));
        }

        [Test]
        public void GetServiceException()
        {
            var factory = CreateServiceFactory().AddService<Implementation1>();

            Assert.Throws<ArgumentException>(() => factory.WithOption("test"));
        }

        private static IServiceFactory<IInterface> CreateServiceFactory(FactoryOptions options = null)
        {
            var services = new ServiceCollection();
            services.AddSingleton<Implementation1>();
            services.AddSingleton<Implementation2>();

            services.AddSingleton(new FactoryOptions {Implementor = options?.Implementor, Implementors = options?.Implementors});
            var serviceProvider = services.BuildServiceProvider();
            return new ServiceFactory<IInterface>(serviceProvider);
        }

        private class FactoryOptions
        {
            public string Implementor { get; set; }
            public IEnumerable<string> Implementors { get; set; }
        }

        private interface IInterface
        {
        }

        private class Implementation1 : IInterface
        {
        }

        private class Implementation2 : IInterface
        {
        }
    }
}