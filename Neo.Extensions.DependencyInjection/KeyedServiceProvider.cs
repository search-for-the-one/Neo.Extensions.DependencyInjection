using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public class KeyedServiceProvider : IKeyedServiceProvider
    {
        private readonly Dictionary<string, Dictionary<string, IServiceProvider>> serviceProviders = new Dictionary<string, Dictionary<string, IServiceProvider>>();

        public IKeyedServiceProvider Add(IConfigurationSection configurationSection, Action<IServiceCollection, IConfigurationSection, IServiceProvider> action, IServiceProvider rootServiceProvider)
        {
            var childServiceProviders = new Dictionary<string, IServiceProvider>();

            foreach (var configurationSectionChild in configurationSection.GetChildren())
            {
                var services = new ServiceCollection();
                action(services, configurationSectionChild, rootServiceProvider);
                childServiceProviders.Add(configurationSectionChild.Key, services.BuildServiceProvider());
            }

            serviceProviders.Add(configurationSection.Key, childServiceProviders);
            return this;
        }

        public T GetRequiredService<T>(string section, string key) => serviceProviders[section][key].GetRequiredService<T>();

        public IEnumerable<string> KeysOfSection(string section) => serviceProviders[section].Keys;
        public IEnumerable<string> Sections() => serviceProviders.Keys;
    }
}