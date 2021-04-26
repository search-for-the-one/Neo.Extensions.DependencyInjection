using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Configurations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Test]
        public void ListBindingWithNull()
        {
            var builder = new NeoConfigurationBuilder();
            var configuration = builder.Build();
            
            var services = new ServiceCollection();
            services.AddConfig<ListConfig>(configuration);
            var serviceProvider = services.BuildServiceProvider();

            var config = serviceProvider.GetRequiredService<ListConfig>();
            Assert.IsNotNull(config);
            Assert.IsEmpty(config);
        }
        
        [TestCase("null", 0)]
        [TestCase("[]", 0)]
        [TestCase("[\"one\"]", 1)]
        [TestCase("[\"one\", \"two\", \"three\"]", 3)]
        public void ListBinding(string value, int count)
        {
            var builder = new NeoConfigurationBuilder();
            builder.AddJson($"{{\"{nameof(ListConfig)}\": {value}}}");
            var configuration = builder.Build();
            
            var services = new ServiceCollection();
            services.AddConfig<ListConfig>(configuration);
            var serviceProvider = services.BuildServiceProvider();

            var config = serviceProvider.GetRequiredService<ListConfig>();
            Assert.AreEqual(count, config.Count);
        }
        
        private class ListConfig: List<string>, IConfig
        {
            
        }
        
        [Test]
        public void AddKeyedConfigs()
        {
            var builder = new NeoConfigurationBuilder();
            var myConfigs = new Dictionary<string, MyConfig>
            {
                {"one", new MyConfig {Name = "One", SubConfig = new MySubConfig {SubName = "Sub One"}}},
                {"two", new MyConfig {Name = "Two", SubConfig = new MySubConfig {SubName = "Sub Two"}}}
            };
            builder.AddJson(JsonConvert.SerializeObject(myConfigs));
            var configuration = builder.Build();
            
            var services = new ServiceCollection();
            services.AddKeyedConfig<MyConfig>(configuration);
            var serviceProvider = services.BuildServiceProvider();

            var configs = serviceProvider.GetRequiredService<IKeyedConfigs<MyConfig>>();
            CollectionAssert.AreEqual(ToEnumerable(myConfigs), ToEnumerable(configs));
            
            Assert.IsNotNull(serviceProvider.GetRequiredService<IReadOnlyDictionary<string, MyConfig>>());
            Assert.IsNotNull(serviceProvider.GetRequiredService<IConfig>());

            IEnumerable<string> ToEnumerable(IReadOnlyDictionary<string, MyConfig> dict) => dict.OrderBy(x => x.Key).Select(kv => $"{kv.Key} {kv.Value}");
        }
        
        private class MyConfig : IConfig
        {
            public string Name { get; set; }
            public MySubConfig SubConfig { get; set; } = MySubConfig.Default;
            public override string ToString()
            {
                return $"{Name} {SubConfig.SubName}";
            }
        }
        
        private class MySubConfig
        {
            public string SubName { get; set; }

            public static readonly MySubConfig Default = new MySubConfig {SubName = "Default"};
        }
        
        [Test]
        public void AddKeyedServices()
        {
            var services = new ServiceCollection();
            services.AddSingletonKeyedServices<IInterface1>(c =>
                c.AddService<MultipleInterfaceImplementation1>()
                    .AddService<MultipleInterfaceImplementation1>("one")
                    .AddService(new MultipleInterfaceImplementation2())
                    .AddService("two", new MultipleInterfaceImplementation2()));
            services.AddSingleton<MultipleInterfaceImplementation1>();
            var serviceProvider = services.BuildServiceProvider();
            var implementations = serviceProvider.GetRequiredService<IReadOnlyDictionary<string, IInterface1>>();

            Assert.IsTrue(implementations.TryGetValue(nameof(MultipleInterfaceImplementation1), out var value1) && value1 is MultipleInterfaceImplementation1);
            Assert.IsTrue(implementations.TryGetValue(nameof(MultipleInterfaceImplementation2), out var value2) && value2 is MultipleInterfaceImplementation2);
            Assert.IsTrue(implementations.TryGetValue("one", out var one) && one is MultipleInterfaceImplementation1);
            Assert.IsTrue(implementations.TryGetValue("two", out var two) && two is MultipleInterfaceImplementation2);
        }

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