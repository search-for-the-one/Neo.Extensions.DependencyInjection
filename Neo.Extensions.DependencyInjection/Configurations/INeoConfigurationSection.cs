using Microsoft.Extensions.Configuration;

namespace Neo.Extensions.DependencyInjection.Configurations
{
    public interface INeoConfigurationSection : INeoConfiguration, IConfigurationSection
    {
    }
}