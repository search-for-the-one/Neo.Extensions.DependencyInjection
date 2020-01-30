using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Neo.Extensions.DependencyInjection.Tests
{
    public class KeyedServiceProviderTests
    {
        public KeyedServiceProviderTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("KeyedServiceProviderTests.json", optional: false, reloadOnChange: false);

            configuration = builder.Build();
        }

        private readonly IConfiguration configuration;

        [Test]
        public void SectionRegistrationWorks()
        {
            var keyedServiceProvider = new KeyedServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Add(configuration.GetSection("ShopCalculationSection"),
                    (services, configSection, rootSp) =>
                    {
                        services.AddSingleton(PriceCalculatorFactory.Create);
                        services.AddSingleton<IInvoicePriceCalculator, InvoicePriceCalculator>();
                        services.AddSingleton<IPostPriceCalculator, PostPriceCalculator>();

                        services.AddConfig<InvoicePriceCalculatorOptions>(configSection);
                        services.AddConfig<PostPriceCalculatorOptions>(configSection);
                        services.AddConfig<PriceCalculatorFactoryOptions>(configSection);
                    });

            var flowerShopServiceProvider = keyedServiceProvider.GetRequiredService<IServiceProvider>("ShopCalculationSection", "FlowerShop");
            Assert.AreEqual(110, flowerShopServiceProvider.GetRequiredService<IPriceCalculator>().Calculate());
            Assert.AreEqual(110, keyedServiceProvider.GetRequiredService<IPriceCalculator>("ShopCalculationSection", "FlowerShop").Calculate());

            var dildoShopServiceProvider = keyedServiceProvider.GetRequiredService<IServiceProvider>("ShopCalculationSection", "BottleShop");
            Assert.AreEqual(190, dildoShopServiceProvider.GetRequiredService<IPriceCalculator>().Calculate());
            Assert.AreEqual(190, keyedServiceProvider.GetRequiredService<IPriceCalculator>("ShopCalculationSection", "BottleShop").Calculate());
        }

        [Test]
        public void GettingSectionsAndKeysWroks()
        {
            var keyedServiceProvider = new KeyedServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Add(configuration.GetSection("ShopCalculationSection"),
                    (services, configSection, rootSp) =>
                    {
                        services.AddSingleton<IInvoicePriceCalculator, InvoicePriceCalculator>();

                        services.AddConfig<InvoicePriceCalculatorOptions>(configSection);
                    }, "Section1")
                .Add(configuration.GetSection("ShopCalculationSection"),
                    (services, configSection, rootSp) =>
                    {
                        services.AddSingleton<IInvoicePriceCalculator, InvoicePriceCalculator>();

                        services.AddConfig<InvoicePriceCalculatorOptions>(configSection);
                    }, "Section2");

            Assert.AreEqual(new[] {"Section1", "Section2"}, keyedServiceProvider.Sections().OrderBy(s => s).ToArray());
            Assert.AreEqual(new[] {"BottleShop", "FlowerShop"}, keyedServiceProvider.Keys("Section1").OrderBy(k => k).ToList());
            Assert.AreEqual(new[] {"BottleShop", "FlowerShop"}, keyedServiceProvider.Keys("Section2").OrderBy(k => k).ToList());

            var keysBySection = keyedServiceProvider.Keys();
            Assert.AreEqual(new[] {"Section1", "Section2"}, keysBySection.Keys.OrderBy(s => s).ToArray());
            Assert.AreEqual(new[] {"BottleShop", "FlowerShop"}, keysBySection["Section1"].OrderBy(k => k).ToList());
            Assert.AreEqual(new[] {"BottleShop", "FlowerShop"}, keysBySection["Section2"].OrderBy(k => k).ToList());
        }

        private interface IPriceCalculator
        {
            int Calculate();
        }

        private interface IInvoicePriceCalculator
        {
            int Calculate();
        }

        private interface IPostPriceCalculator
        {
            int Calculate();
        }

        private class PriceCalculator : IPriceCalculator
        {
            private readonly IInvoicePriceCalculator invoicePriceCalculator;
            private readonly IPostPriceCalculator postPriceCalculator;

            public PriceCalculator(IInvoicePriceCalculator invoicePriceCalculator, IPostPriceCalculator postPriceCalculator)
            {
                this.invoicePriceCalculator = invoicePriceCalculator;
                this.postPriceCalculator = postPriceCalculator;
            }

            public int Calculate() => invoicePriceCalculator.Calculate() + postPriceCalculator.Calculate();
        }

        private class PriceCalculatorWithDiscount : IPriceCalculator
        {
            private readonly IInvoicePriceCalculator invoicePriceCalculator;
            private readonly IPostPriceCalculator postPriceCalculator;
            private readonly int discountAmount;

            public PriceCalculatorWithDiscount(IInvoicePriceCalculator invoicePriceCalculator, IPostPriceCalculator postPriceCalculator, int discountAmount)
            {
                this.invoicePriceCalculator = invoicePriceCalculator;
                this.postPriceCalculator = postPriceCalculator;
                this.discountAmount = discountAmount;
            }

            public int Calculate() => invoicePriceCalculator.Calculate() + postPriceCalculator.Calculate() - discountAmount;
        }

        private static class PriceCalculatorFactory
        {
            public static IPriceCalculator Create(IServiceProvider serviceProvider)
            {
                var options = serviceProvider.GetRequiredService<PriceCalculatorFactoryOptions>();
                var invoicePriceCalculator = serviceProvider.GetRequiredService<IInvoicePriceCalculator>();
                var postPriceCalculator = serviceProvider.GetRequiredService<IPostPriceCalculator>();

                return options.DiscountAmount > 0
                    ? (IPriceCalculator) new PriceCalculatorWithDiscount(invoicePriceCalculator, postPriceCalculator, options.DiscountAmount)
                    : new PriceCalculator(invoicePriceCalculator, postPriceCalculator);
            }
        }

        private class InvoicePriceCalculator : IInvoicePriceCalculator
        {
            private readonly InvoicePriceCalculatorOptions options;

            public InvoicePriceCalculator(InvoicePriceCalculatorOptions options) => this.options = options;

            public int Calculate() => options.MockPrice;
        }

        private class PostPriceCalculator : IPostPriceCalculator
        {
            private readonly PostPriceCalculatorOptions options;

            public PostPriceCalculator(PostPriceCalculatorOptions options) => this.options = options;

            public int Calculate() => options.MockPrice;
        }

        internal class InvoicePriceCalculatorOptions : IConfig
        {
            public int MockPrice { get; set; }
        }

        internal class PostPriceCalculatorOptions : IConfig
        {
            public int MockPrice { get; set; }
        }

        internal class PriceCalculatorFactoryOptions : IConfig
        {
            public int DiscountAmount { get; set; }
        }
    }
}