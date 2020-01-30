using System.Collections.Generic;
using System.Linq;

namespace Neo.Extensions.DependencyInjection
{
    public static class ConfigExtensions
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, IConfig>>> ToNamedDictionary(this IKeyedServiceProvider keyedServiceProvider) =>
            keyedServiceProvider.GetRequiredService<IEnumerable<IConfig>>()
                .ToDictionary(sectionKvp => sectionKvp.Key, sectionKvp => sectionKvp.Value
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToDictionary(c => c.GetType().FullName, c => c)));

        public static Dictionary<string, IConfig> ToNamedDictionary(this IEnumerable<IConfig> configs) => configs.ToDictionary(c => c.GetType().FullName, c => c);
    }
}