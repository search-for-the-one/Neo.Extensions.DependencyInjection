using Microsoft.Extensions.DependencyInjection;
using Neo.Extensions.DependencyInjection.Tests.Handlers;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    internal class ServiceFactoryExtensionsTests
    {
        [Test]
        public void CreateFactory()
        {
            var services = new ServiceCollection();

            services.AddSingletonFromFactory<IHandler>(f => f
                .AddService<TestHandler>()
                .AddService<FunHandler>()
                .WithOption(nameof(TestHandler)));

            var serviceProvider = services.BuildServiceProvider();
            Assert.AreEqual(typeof(TestHandler), serviceProvider.GetService<IHandler>().GetType());
        }
    }
}
