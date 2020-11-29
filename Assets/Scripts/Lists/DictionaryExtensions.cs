using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Lists
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<TValue> TryGetMany<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            return keys.Where(dictionary.ContainsKey).Select(k => dictionary[k]);
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            dictionary.TryGetValue(key, out var value);
            return value;
        }
    }
}