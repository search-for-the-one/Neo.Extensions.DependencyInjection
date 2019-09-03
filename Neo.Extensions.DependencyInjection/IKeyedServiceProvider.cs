using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Extensions.DependencyInjection
{
    public interface IKeyedServiceProvider
    {
        T GetRequiredService<T>(string section, string key);
        IEnumerable<string> KeysOfSection(string section);
        IEnumerable<string> Sections();
    }
}