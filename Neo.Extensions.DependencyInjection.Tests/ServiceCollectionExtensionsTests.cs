using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Test]
        public void AddSingletonFromFactory()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1>(f => f
                .AddService<Interface1Implementation>()
                .AddService<MultipleInterfaceImplementation1>()
                .WithOption(nameof(Interface1Implementation)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(Interface1Implementation), serviceProvider.GetService<IInterface1>().GetType());
        }

        [Test]
        public void AddListOfSingletonsFromFactory()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1>(f => f
                .AddService<Interface1Implementation>()
                .AddService<MultipleInterfaceImplementation1>()
                .WithOption(new []{nameof(Interface1Implementation), nameof(MultipleInterfaceImplementation1)}));

            var serviceProvider = services.BuildServiceProvider();
            var instances = serviceProvider.GetService<IEnumerable<IInterface1>>().ToList();
            Assert.AreEqual(2, instances.Count);
            CollectionAssert.AreEqual(new []{typeof(Interface1Implementation), typeof(MultipleInterfaceImplementation1)}, instances.Select(f => f.GetType()));
        }

        [Test]
        public void AddSingletonFromFactoryForMultipleInterfaces()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1, IInterface2, IInterface3>(f => f
                .AddService<MultipleInterfaceImplementation1>()
                .WithOption(nameof(MultipleInterfaceImplementation1)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface3>().GetType());
        }

        [Test]
        public void AddListOfSingletonsFromFactoryForMultipleInterfaces()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1, IInterface2, IInterface3>(f => f
                .AddService<MultipleInterfaceImplementation1>()
                .AddService<MultipleInterfaceImplementation2>()
                .WithOption(new []{nameof(MultipleInterfaceImplementation1), nameof(MultipleInterfaceImplementation2)}));

            var serviceProvider = services.BuildServiceProvider();
            var instances = serviceProvider.GetService<IEnumerable<IInterface1>>().ToList();
            Assert.AreEqual(2, instances.Count);
            CollectionAssert.AreEqual(new []{typeof(MultipleInterfaceImplementation1), typeof(MultipleInterfaceImplementation2)}, instances.Select(f => f.GetType()));
        }

        [Test]
        public void AddSingletonWithProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementation1>(Provider);

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithInstance()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementation1>(new MultipleInterfaceImplementation1());

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithType()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementation1>();

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithType2()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementation1>();
            services.AddSingleton<IInterface1, IInterface2, MultipleInterfaceImplementation2>();

            var serviceProvider = services.BuildServiceProvider();

            Assert.AreEqual(2, serviceProvider.GetService<IEnumerable<IInterface1>>().Count());
            Assert.AreEqual(2, serviceProvider.GetService<IEnumerable<IInterface2>>().Count());
            Assert.AreEqual(1, serviceProvider.GetService<IEnumerable<IInterface3>>().Count());

            Assert.AreEqual(typeof(MultipleInterfaceImplementation1), serviceProvider.GetService<MultipleInterfaceImplementation1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementation2), serviceProvider.GetService<MultipleInterfaceImplementation2>().GetType());
        }

        private static MultipleInterfaceImplementation1 Provider(IServiceProvider serviceProvider) => new MultipleInterfaceImplementation1();

        private interface IInterface1
        {
        }

        private interface IInterface2
        {
        }

        private interface IInterface3
        {
        }

        private class Interface1Implementation : IInterface1
        {
        }

        private class MultipleInterfaceImplementation1 : IInterface1, IInterface2, IInterface3
        {
        }

        private class MultipleInterfaceImplementation2 : IInterface1, IInterface2, IInterface3
        {
        }
    }
}