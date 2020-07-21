using System.Collections.Generic;

namespace Neo.Extensions.DependencyInjection
{
    public interface IKeyedConfigs<TConfig> : IReadOnlyDictionary<string, TConfig>, IConfig where TConfig : class, IConfig
    {
        
    }
}