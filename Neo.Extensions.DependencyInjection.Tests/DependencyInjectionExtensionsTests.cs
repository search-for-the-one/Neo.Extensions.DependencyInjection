using System;
using Neo.Extensions.DependencyInjection.Tests.Handlers;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    internal class DependencyInjectionExtensionsTests
    {
        [Test]
        public void CreateFactory()
        {
            var factory = ((IServiceProvider) null).CreateFactory<IHandler, TestHandler>();
            Assert.NotNull(factory);
        }
    }
}
