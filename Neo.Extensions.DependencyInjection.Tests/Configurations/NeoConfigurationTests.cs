using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Configurations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests.Configurations
{
    internal class NeoConfigurationTests
    {
        [TestCase(null)]
        [TestCase("abc")]
        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(true)]
        [TestCase(153.0074)]
        public void KeyIndexTest(object value)
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = value}));

            var key = "Value";
            var configuration = new ConfigurationBuilder().AddJsonFile(file).Build();
            var neoConfiguration = new NeoConfigurationBuilder().AddJsonFile(file).Build();

            Assert.AreEqual(configuration[key], neoConfiguration[key]);
        }

        [Test]
        public void GetChildrenTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(
                new {One = 1, Two = "two", Three = new[] {1, 2, 3}, Four = new {Five = "five", Six = "six"}}));

            var configuration = new ConfigurationBuilder().AddJsonFile(file).Build();
            var neoConfiguration = new NeoConfigurationBuilder().AddJsonFile(file).Build();

            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Path).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Path).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Key).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Key).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Value).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Value).OrderBy(x => x));
        }

        [TestCase(1)]
        [TestCase("Test")]
        public void GetChildrenOfValueTypeTest(object obj)
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {obj}));

            var configuration = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection("obj");
            var neoConfiguration = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection("obj");

            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Path).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Path).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Key).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Key).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Value).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Value).OrderBy(x => x));
        }

        [Test]
        public void GetChildrenOfArrayTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {arr = new List<int> {1, 2, 3}}));

            var configuration = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection("arr");
            var neoConfiguration = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection("arr");

            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Path).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Path).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Key).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Key).OrderBy(x => x));
            CollectionAssert.AreEqual(configuration.GetChildren().Select(x => x.Value).OrderBy(x => x),
                neoConfiguration.GetChildren().Select(x => x.Value).OrderBy(x => x));
        }

        [TestCase(null)]
        [TestCase("abc")]
        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(true)]
        public void GetSectionBasicValueTest(object value)
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = value}));

            var key = "Value";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);

            Assert.AreEqual(configurationSection.Key, neoConfigurationSection.Key);
            Assert.AreEqual(configurationSection.Path, configurationSection.Path);
            Assert.AreEqual(configurationSection.Value, neoConfigurationSection.Value);
        }

        [Test]
        public void GetSectionArrayTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = new List<int> {1, 2, 3}}));

            var key = "Value";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);

            for (var i = -1; i <= 3; i++)
            {
                Assert.AreEqual(configurationSection.GetSection(i.ToString()).Key,
                    neoConfigurationSection.GetSection(i.ToString()).Key);
                Assert.AreEqual(configurationSection.GetSection(i.ToString()).Path,
                    configurationSection.GetSection(i.ToString()).Path);
                Assert.AreEqual(configurationSection.GetSection(i.ToString()).Value,
                    neoConfigurationSection.GetSection(i.ToString()).Value);
            }
        }


        [Test]
        public void MultiLevelTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {One = new {Two = 1}}));

            const string one = "One";
            const string two = "Two";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(one).GetSection(two);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(one).GetSection(two);

            Assert.AreEqual(configurationSection.Key, neoConfigurationSection.Key);
            Assert.AreEqual(configurationSection.Path, configurationSection.Path);
            Assert.AreEqual(configurationSection.Value, neoConfigurationSection.Value);
        }


        [Test]
        public void NotExistingTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = "abc"}));

            const string key = "Value1";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);

            Assert.AreEqual(configurationSection.Key, neoConfigurationSection.Key);
            Assert.AreEqual(configurationSection.Path, configurationSection.Path);
            Assert.AreEqual(configurationSection.Value, neoConfigurationSection.Value);
        }

        [Test]
        public void ArrayTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = new[] {1, 2, 3}}));

            var key = "Value";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);

            Assert.AreEqual(configurationSection.Key, neoConfigurationSection.Key);
            Assert.AreEqual(configurationSection.Path, configurationSection.Path);
            Assert.AreEqual(configurationSection.Value, neoConfigurationSection.Value);
        }

        [Test]
        public void DictTest()
        {
            var file = $"{Guid.NewGuid()}.json";
            File.WriteAllText(file, JsonConvert.SerializeObject(new {Value = new {One = "a", Two = "b"}}));

            var key = "Value";
            var configurationSection = new ConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);
            var neoConfigurationSection = new NeoConfigurationBuilder().AddJsonFile(file).Build().GetSection(key);

            Assert.AreEqual(configurationSection.Key, neoConfigurationSection.Key);
            Assert.AreEqual(configurationSection.Path, configurationSection.Path);
            Assert.AreEqual(configurationSection.Value, neoConfigurationSection.Value);
        }

        [Test]
        public void AddConfigTestWithParameter()
        {
            var services = new ServiceCollection();
            var baseConfig = new BaseConfig
            {
                Name = "base name"
            };
            services.AddSingleton(baseConfig);

            var configuration = new NeoConfigurationBuilder().AddJson(JsonConvert.SerializeObject(
                new
                {
                    MyConfig = new
                    {
                        Value = "new value",
                        SubConfig = new
                        {
                            Value = "new sub value"
                        }
                    }
                })).Build();

            services.AddConfig<MyConfig>(configuration);

            var expected = new MyConfig(baseConfig)
            {
                Value = "new value",
                SubConfig = new SubConfig(baseConfig)
                {
                    Value = "new sub value"
                }
            };

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(services.BuildServiceProvider().GetRequiredService<MyConfig>()));
        }

        [TestCaseSource(nameof(AddConfigValueTypeTestCases))]
        public void AddConfigValueTypeTest(object obj)
        {
            var expected = new ValueTypeConfig
            {
                ShortValue = 1,
                UshortValue = 2,
                IntValue = 3,
                UIntValue = 4,
                LongValue = 5,
                ULongValue = 6,
                FloatValue = (float) -37.825039,
                DoubleValue = 144.971512,
                DecimalValue = (decimal) -37.81612,
                CharValue = 'a',
                StringValue = "abc",
                DateTime = new DateTime(2020, 6, 26)
            };

            var configuration = new NeoConfigurationBuilder().AddJson(JsonConvert.SerializeObject(obj)).Build();
            var services = new ServiceCollection();
            services.AddConfig<ValueTypeConfig>(configuration);

            Assert.AreEqual(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(services.BuildServiceProvider().GetRequiredService<ValueTypeConfig>()));
        }

        private static IEnumerable<TestCaseData> AddConfigValueTypeTestCases()
        {
            yield return new TestCaseData(new
            {
                ValueTypeConfig = new
                {
                    ShortValue = 1,
                    UshortValue = 2,
                    IntValue = 3,
                    UIntValue = 4,
                    LongValue = 5,
                    ULongValue = 6,
                    FloatValue = (float) -37.825039,
                    DoubleValue = 144.971512,
                    DecimalValue = (decimal) -37.81612,
                    CharValue = 'a',
                    StringValue = "abc",
                    DateTime = new DateTime(2020, 6, 26)
                }
            });
            yield return new TestCaseData(new
            {
                ValueTypeConfig = new
                {
                    ShortValue = "1",
                    UshortValue = "2",
                    IntValue = "3",
                    UIntValue = "4",
                    LongValue = "5",
                    ULongValue = "6",
                    FloatValue = "-37.825039",
                    DoubleValue = "144.971512",
                    DecimalValue = "-37.81612",
                    CharValue = 'a',
                    StringValue = "abc",
                    DateTime = new DateTime(2020, 6, 26).ToString(CultureInfo.InvariantCulture)
                }
            });
        }

        private class BaseConfig
        {
            public string Name { get; set; } = string.Empty;
        }

        private class MyConfig : IConfig
        {
            public MyConfig(BaseConfig config)
            {
                Name = $"config {config.Name}";
            }

            public string Name { get; }
            public string Value { get; set; }
            public SubConfig SubConfig { get; set; }
        }

        private class SubConfig
        {
            public SubConfig(BaseConfig config)
            {
                Name = $"sub {config.Name}";
            }

            public string Name { get; }
            public string Value { get; set; }
        }

        private class ValueTypeConfig : IConfig
        {
            public short ShortValue { get; set; }
            public ushort UshortValue { get; set; }
            public int IntValue { get; set; }
            public uint UIntValue { get; set; }
            public long LongValue { get; set; }
            public ulong ULongValue { get; set; }
            public float FloatValue { get; set; }
            public double DoubleValue { get; set; }
            public decimal DecimalValue { get; set; }
            public char CharValue { get; set; }
            public string StringValue { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
}