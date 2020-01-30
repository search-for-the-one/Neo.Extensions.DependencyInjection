using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public class KeyedServiceProvider : IKeyedServiceProvider
    {
        private readonly IServiceProvider rootServiceProvider;
        private readonly IDictionary<string, Dictionary<string, IServiceProvider>> serviceProviders = new Dictionary<string, Dictionary<string, IServiceProvider>>();

        public KeyedServiceProvider(IServiceProvider rootServiceProvider) => this.rootServiceProvider = rootServiceProvider;

        public KeyedServiceProvider Add(
            IConfigurationSection configurationSection, 
            Action<IServiceCollection, IConfigurationSection, IServiceProvider> action,
            string name = null)
        {
            var childServiceProviders = new Dictionary<string, IServiceProvider>();

            foreach (var configurationSectionChild in configurationSection.GetChildren())
            {
                var services = new ServiceCollection();
                action(services, configurationSectionChild, rootServiceProvider);
                childServiceProviders.Add(configurationSectionChild.Key, services.BuildServiceProvider());
            }

            serviceProviders.Add(name ?? configurationSection.Key, childServiceProviders);
            return this;
        }

        public T GetRequiredService<T>(string section, string key) => serviceProviders[section][key].GetRequiredService<T>();
        public IDictionary<string, T> GetRequiredService<T>(string section) => serviceProviders[section].ToDictionary(kvp => kvp.Key, kvp => GetRequiredService<T>(section, kvp.Key));
        public IDictionary<string, IDictionary<string, T>> GetRequiredService<T>() => serviceProviders.ToDictionary(kvp => kvp.Key, kvp => GetRequiredService<T>(kvp.Key));

        public IEnumerable<string> Sections() => serviceProviders.Keys;
        public IEnumerable<string> Keys(string section) => serviceProviders[section].Keys;
        public IDictionary<string, IEnumerable<string>> Keys() => serviceProviders.ToDictionary(kvp => kvp.Key, kvp => Keys(kvp.Key));
    }
}