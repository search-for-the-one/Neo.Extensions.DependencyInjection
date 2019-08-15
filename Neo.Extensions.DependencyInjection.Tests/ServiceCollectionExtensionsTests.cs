using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Tests.Mocks;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Test]
        public void CreateFactory()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1>(f => f
                .AddService<SingleInterfaceImplementor1>()
                .AddService<MultipleInterfaceImplementor1>()
                .WithOption(nameof(SingleInterfaceImplementor1)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(SingleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
        }

        [Test]
        public void CreateFactoryForMultipleInterface()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1, IInterface2, IInterface3>(f => f
                .AddService<MultipleInterfaceImplementor1>()
                .WithOption(nameof(MultipleInterfaceImplementor1)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface3>().GetType());
        }

        [Test]
        public void AddSingletonWithProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor1>(Provider);

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithInstance()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor1>(new MultipleInterfaceImplementor1());

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithType()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor1>();

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithType2()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor1>();
            services.AddSingleton<IInterface1, IInterface2, MultipleInterfaceImplementor2>();

            var serviceProvider = services.BuildServiceProvider();

            Assert.AreEqual(2, serviceProvider.GetService<IEnumerable<IInterface1>>().Count());
            Assert.AreEqual(2, serviceProvider.GetService<IEnumerable<IInterface2>>().Count());
            Assert.AreEqual(1, serviceProvider.GetService<IEnumerable<IInterface3>>().Count());

            Assert.AreEqual(typeof(MultipleInterfaceImplementor1), serviceProvider.GetService<MultipleInterfaceImplementor1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor2), serviceProvider.GetService<MultipleInterfaceImplementor2>().GetType());
        }

        private static MultipleInterfaceImplementor1 Provider(IServiceProvider serviceProvider) => new MultipleInterfaceImplementor1();
    }
}