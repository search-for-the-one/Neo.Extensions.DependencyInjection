using System.Collections.Generic;

namespace Neo.Extensions.DependencyInjection
{
    public interface IKeyedServiceProvider
    {
        T GetRequiredService<T>(string section, string key);
        IDictionary<string, T> GetRequiredService<T>(string section);
        IDictionary<string, IDictionary<string, T>> GetRequiredService<T>();

        IEnumerable<string> Sections();
        IEnumerable<string> Keys(string section);
        IDictionary<string, IEnumerable<string>> Keys();
    }
}