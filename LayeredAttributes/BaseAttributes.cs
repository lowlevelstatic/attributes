using System;
using System.Collections.Generic;

namespace LayeredAttributes
{
    public class BaseAttributes
    {
        private readonly Dictionary<AttributeKey, int> m_baseAttributes = new();
        
        public void SetAttribute(AttributeKey attKey, int value) => m_baseAttributes[attKey] = value;

        public int GetAttribute(AttributeKey attKey) => m_baseAttributes.TryGetValue(attKey, out var value)
            ? value
            : throw new ArgumentException($"Requested attribute [{attKey}] was never set.", nameof(attKey));
    }
}