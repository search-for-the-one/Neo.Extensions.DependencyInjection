using System;
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
                .AddService<MultipleInterfaceImplementor>()
                .WithOption(nameof(SingleInterfaceImplementor1)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(SingleInterfaceImplementor1), serviceProvider.GetService<IInterface1>().GetType());
        }

        [Test]
        public void CreateFactoryForMultipleInterface()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IInterface1, IInterface2, IInterface3>(f => f
                .AddService<MultipleInterfaceImplementor>()
                .WithOption(nameof(MultipleInterfaceImplementor)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface3>().GetType());
        }

        [Test]
        public void AddSingletonWithProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor>(Provider);

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithInstance()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor>(new MultipleInterfaceImplementor());

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        [Test]
        public void AddSingletonWithType()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInterface1, IInterface2, IInterface3, MultipleInterfaceImplementor>();

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface1>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface2>().GetType());
            Assert.AreEqual(typeof(MultipleInterfaceImplementor), serviceProvider.GetService<IInterface3>().GetType());

            Assert.AreSame(serviceProvider.GetService<IInterface1>(), serviceProvider.GetService<IInterface2>());
            Assert.AreSame(serviceProvider.GetService<IInterface2>(), serviceProvider.GetService<IInterface3>());
        }

        private static MultipleInterfaceImplementor Provider(IServiceProvider serviceProvider) => new MultipleInterfaceImplementor();
    }
}