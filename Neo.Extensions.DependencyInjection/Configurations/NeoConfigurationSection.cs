namespace Neo.Extensions.DependencyInjection.Configurations
{
    public class NeoConfigurationSection : NeoConfiguration, INeoConfigurationSection
    {
        public NeoConfigurationSection(object data, string key, string path) : base(data, path)
        {
            Key = key;
            Path = path;
            Value = IsValueType(data) ? data?.ToString() : null;
        }

        public string Key { get; }
        public string Path { get; }
        public string Value { get; set; }
    }
}