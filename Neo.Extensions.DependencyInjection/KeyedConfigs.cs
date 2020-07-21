using System;
using System.Collections.Generic;

namespace Neo.Extensions.DependencyInjection
{
    internal class KeyedConfigs<TConfig> : Dictionary<string, TConfig>, IKeyedConfigs<TConfig> where TConfig : class, IConfig
    {
        public KeyedConfigs() : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}