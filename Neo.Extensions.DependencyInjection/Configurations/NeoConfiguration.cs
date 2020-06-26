using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using IJsonObject = System.Collections.Generic.IDictionary<string, object>;

namespace Neo.Extensions.DependencyInjection.Configurations
{
    public class NeoConfiguration : INeoConfiguration
    {
        private const char KeyDelimiter = ':';
        private readonly object data;
        private readonly string path;

        public NeoConfiguration(object data, string path = "")
        {
            this.data = data;
            this.path = path;
        }

        public IConfigurationSection GetSection(string key)
        {
            return new NeoConfigurationSection(Get(key), key, GetPath(key));
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return data switch
            {
                IJsonObject jsonObject => jsonObject.Keys.Select(GetSection),
                IList<object> listObject => Enumerable.Range(0, listObject.Count).Select(i => GetSection(i.ToString())),
                _ => Enumerable.Empty<IConfigurationSection>()
            };
        }

        public IChangeToken GetReloadToken()
        {
            return new ConfigurationReloadToken();
        }

        public string this[string key]
        {
            get
            {
                var obj = Get(key);
                return IsValueType(obj) ? obj?.ToString() : null;
            }
            set => throw new InvalidOperationException();
        }

        public string ToJson()
        {
            return data == null ? null : JsonConvert.SerializeObject(data);
        }

        private object Get(string key)
        {
            if (data == null)
                return null;

            if (data is IJsonObject jsonObject)
            {
                if (jsonObject.TryGetValue(key, out var value))
                    return IsValueType(value) ? value ?? string.Empty : value;

                return null;
            }

            if (data is IList<object> objectList && int.TryParse(key, out var index) && index >= 0 && index < objectList.Count)
                return IsValueType(objectList[index]) ? objectList[index] ?? string.Empty : objectList[index];

            return null;
        }

        private string GetPath(string key)
        {
            return string.IsNullOrEmpty(path) ? key : $"{path}{KeyDelimiter}{key}";
        }

        protected static bool IsValueType(object value)
        {
            return value == null || !(value is IJsonObject) && !(value is IList);
        }
    }
}