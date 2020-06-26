using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using IJsonObject = System.Collections.Generic.IDictionary<string, object>;

namespace Neo.Extensions.DependencyInjection.Configurations
{
    public class NeoConfigurationBuilder : INeoConfigurationBuilder
    {
        private object root;

        public NeoConfigurationBuilder AddJsonFile(string file)
        {
            return !File.Exists(file) ? this : AddJson(File.ReadAllText(file));
        }

        public NeoConfigurationBuilder AddJson(string json)
        {
            ApplyConfiguration(JsonConvert.DeserializeObject<ExpandoObject>(json));
            return this;
        }

        public IConfiguration Build()
        {
            return new NeoConfiguration(root);
        }

        public NeoConfigurationBuilder AddEnvironmentVariables()
        {
            var obj = ToObject(Environment.GetEnvironmentVariables().Cast<DictionaryEntry>().Select(kv => (Key: (string) kv.Key, kv.Value)));
            ApplyConfiguration(obj as IJsonObject);
            return this;
        }

        private void ApplyConfiguration(object obj)
        {
            root = ApplyConfiguration(obj, root);
        }

        private static object ApplyConfiguration(object obj, object currentRoot)
        {
            if (!(obj is IJsonObject jsonObject) || !(currentRoot is IJsonObject current))
                return obj;

            foreach (var kv in jsonObject)
            {
                var key = kv.Key;
                var value = kv.Value;

                current[key] = current.ContainsKey(key) ? ApplyConfiguration(value, current[key]) : value;
            }

            return current;
        }

        protected static object ToObject(IEnumerable<(string Key, object Value)> variables)
        {
            return ToObject(variables.Select(x => (Keys: x.Key.Split(new[] {"__"}, StringSplitOptions.RemoveEmptyEntries), x.Value)), 0);
        }

        private static object ToObject(IEnumerable<(string[] Keys, object Value)> variables, int index)
        {
            var groups = variables.GroupBy(x => x.Keys[index]).ToList();

            var obj = new Dictionary<string, object>(groups.Count);
            foreach (var group in groups)
            {
                var subValues = group.Select(x => x).ToList();
                if (subValues.Any(x => x.Keys.Length == index + 1))
                    obj[group.Key] = subValues.First(x => x.Keys.Length == index + 1).Value;
                else
                    obj[group.Key] = ToObject(subValues, index + 1);
            }

            if (IsArrayIndex(obj.Keys))
                return obj.OrderBy(x => int.Parse(x.Key)).Select(x => x.Value).ToList();

            return obj;
        }

        private static bool IsArrayIndex(IEnumerable<string> keys)
        {
            var indexes = keys.Select(x => int.TryParse(x, out var index) ? index : -1).OrderBy(x => x);
            var count = 0;
            return indexes.All(index => index == count++);
        }
    }
}