using Microsoft.Extensions.Configuration;

namespace Neo.Extensions.DependencyInjection.Configurations
{
    public interface INeoConfigurationBuilder
    {
        NeoConfigurationBuilder AddJsonFile(string file);
        NeoConfigurationBuilder AddJson(string json);
        IConfiguration Build();
        NeoConfigurationBuilder AddEnvironmentVariables();
    }
}