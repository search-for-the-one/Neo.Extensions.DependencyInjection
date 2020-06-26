using Microsoft.Extensions.Configuration;

namespace Neo.Extensions.DependencyInjection.Configurations
{
    public interface INeoConfiguration : IConfiguration
    {
        string ToJson();
    }
}