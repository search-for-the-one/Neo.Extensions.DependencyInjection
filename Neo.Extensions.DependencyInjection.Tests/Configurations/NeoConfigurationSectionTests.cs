using System.Collections.Generic;
using Neo.Extensions.DependencyInjection.Configurations;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests.Configurations
{
    internal class NeoConfigurationSectionTests
    {
        [TestCaseSource(nameof(ValueTestCases))]
        public void ValueTest(object data, string value)
        {
            var section = new NeoConfigurationSection(data, "key", "path");

            Assert.AreEqual("key", section.Key);
            Assert.AreEqual("path", section.Path);
            Assert.AreEqual(value, section.Value);
        }

        private static IEnumerable<TestCaseData> ValueTestCases()
        {
            yield return new TestCaseData(null, null);
            yield return new TestCaseData(new Dictionary<string, object>(), null);
            yield return new TestCaseData(new List<string>(), null);
            yield return new TestCaseData(1, "1");
            yield return new TestCaseData(2.01, "2.01");
        }
    }
}