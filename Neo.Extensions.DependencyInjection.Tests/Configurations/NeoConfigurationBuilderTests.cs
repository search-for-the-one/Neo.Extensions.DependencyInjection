using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Neo.Extensions.DependencyInjection.Configurations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests.Configurations
{
    public class NeoConfigurationBuilderTests : NeoConfigurationBuilder
    {
        [TestCaseSource(nameof(AddJsonTestCases))]
        public void AddJsonTest(object a, object b, object merged)
        {
            var builder = new NeoConfigurationBuilder();
            builder.AddJson(JsonConvert.SerializeObject(a));
            builder.AddJson(JsonConvert.SerializeObject(b));

            Assert.AreEqual(JsonConvert.SerializeObject(merged), (builder.Build() as INeoConfiguration)?.ToJson());
        }

        private static IEnumerable<TestCaseData> AddJsonTestCases()
        {
            yield return new TestCaseData(new {Value = 1}, new {Value = 2}, new {Value = 2});
            yield return new TestCaseData(new { }, new {Value = 2}, new {Value = 2});
            yield return new TestCaseData(new {Value = 1}, new { }, new {Value = 1});
            yield return new TestCaseData(new { }, new { }, new { });
            yield return new TestCaseData(new {Value = 1}, new {Value = (string) null}, new {Value = (string) null});

            yield return new TestCaseData(new {Value1 = 1}, new {Value2 = 2}, new {Value1 = 1, Value2 = 2});
            yield return new TestCaseData(new {Value1 = 1, Value2 = 2}, new {Value2 = 3}, new {Value1 = 1, Value2 = 3});
            yield return new TestCaseData(new {Value1 = 1}, new {Value1 = 2, Value2 = 3}, new {Value1 = 2, Value2 = 3});

            yield return new TestCaseData(new {Value1 = 1, Value2 = new {Value21 = 1, Value22 = 2}},
                new {Value1 = 2, Value2 = new {Value21 = 21, Value22 = 22}}, new {Value1 = 2, Value2 = new {Value21 = 21, Value22 = 22}});
            yield return new TestCaseData(new {Value1 = 1, Value2 = new {Value21 = 1, Value22 = 2}},
                new {Value1 = 2}, new {Value1 = 2, Value2 = new {Value21 = 1, Value22 = 2}});
            yield return new TestCaseData(new {Value1 = 1, Value2 = new {Value21 = 1, Value22 = 2}},
                new {Value1 = 2}, new {Value1 = 2, Value2 = new {Value21 = 1, Value22 = 2}});

            yield return new TestCaseData(new {Value = new[] {1, 2, 3}}, new {Value = new[] {4, 5}}, new {Value = new[] {4, 5}});
            yield return new TestCaseData(new {Value = new[] {new {S = "a"}, new {S = "b"}}}, new {Value = new[] {new {S = "c"}}},
                new {Value = new[] {new {S = "c"}}});

            yield return new TestCaseData(new {Value = 1}, new {Value = "a"}, new {Value = "a"});
            yield return new TestCaseData(new {Value = 1}, new {Value = new[] {1, 2, 3}}, new {Value = new[] {1, 2, 3}});
            yield return new TestCaseData(new {Value = new {SubValue = "s"}}, new {Value = new[] {1, 2, 3}}, new {Value = new[] {1, 2, 3}});
        }

        [TestCaseSource(nameof(AddEnvironmentVariablesTestCases))]
        public void AddEnvironmentVariablesTest(IEnumerable<(string Key, object Value)> variables, object expected)
        {
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(ToObject(variables)));
        }

        private static IEnumerable<TestCaseData> AddEnvironmentVariablesTestCases()
        {
            yield return new TestCaseData(new List<(string Key, object Value)> {(Key: "Value", Value: "123")}, new {Value = "123"});
            yield return new TestCaseData(new List<(string Key, object Value)> {(Key: "Value1", Value: "1"), (Key: "Value2", Value: "2")},
                new {Value1 = "1", Value2 = "2"});

            yield return new TestCaseData(new List<(string Key, object Value)> {(Key: "Value", Value: "value"), (Key: "SubValue__Value", Value: "sub value")},
                new {Value = "value", SubValue = new {Value = "sub value"}});

            yield return new TestCaseData(
                new List<(string Key, object Value)>
                {
                    (Key: "Value__1__One", Value: "21"), (Key: "Value__1__Two", Value: "22"),
                    (Key: "Value__0__One", Value: "11"), (Key: "Value__0__Two", Value: "12")
                },
                new {Value = new[] {new {One = "11", Two = "12"}, new {One = "21", Two = "22"}}});
            yield return new TestCaseData(new List<(string Key, object Value)> {(Key: "Value__0", Value: "1"), (Key: "Value__1", Value: "2")},
                new {Value = new[] {"1", "2"}});
            yield return new TestCaseData(new List<(string Key, object Value)> {(Key: "Value__1", Value: "1"), (Key: "Value__2", Value: "2")},
                new {Value = new Dictionary<string, string> {{"1", "1"}, {"2", "2"}}});
        }

        [Test]
        public void AddJsonFileTest()
        {
            var neoConfiguration = new NeoConfigurationBuilder().AddJsonFile("Configurations/appsettings.json")
                .AddJsonFile("Configurations/appsettings.Development.json").AddEnvironmentVariables().Build();

            var configuration = new ConfigurationBuilder().AddJsonFile("Configurations/appsettings.json")
                .AddJsonFile("Configurations/appsettings.Development.json").AddEnvironmentVariables().Build();

            AreEqual(configuration, neoConfiguration);
        }

        private static void AreEqual(IConfiguration a, IConfiguration b)
        {
            var childrenA = a.GetChildren().OrderBy(x => x.Key).ToList();
            var childrenB = b.GetChildren().OrderBy(x => x.Key).ToList();

            Assert.AreEqual(childrenA.Count, childrenB.Count);
            for (var i = 0; i < childrenA.Count; i++)
            {
                var childA = childrenA[i];
                var childB = childrenB[i];
                Assert.AreEqual(childA.Key, childB.Key);
                Assert.AreEqual(childA.Path, childB.Path);
                Assert.AreEqual(childA.Value, childB.Value);
                AreEqual(childA, childB);
            }
        }
    }
}