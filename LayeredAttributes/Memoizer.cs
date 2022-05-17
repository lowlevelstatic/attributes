using System;
using System.Collections.Generic;

namespace LayeredAttributes
{
    public class Memoizer<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> m_cache = new();

        public TValue Get(TKey attKey, Func<TKey, TValue> provider)
        {
            if (!m_cache.TryGetValue(attKey, out var value) && provider != null)
            {
                value = provider.Invoke(attKey);
                m_cache.Add(attKey, value);
            }

            return value;
        }

        public void Invalidate(TKey attKey) => m_cache.Remove(attKey);
    }
}