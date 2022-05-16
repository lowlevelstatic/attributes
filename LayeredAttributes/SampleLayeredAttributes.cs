using System;
using System.Collections.Generic;

namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        private readonly Dictionary<AttributeKey, int> m_baseAttributes = new();

        public void SetBaseAttribute(AttributeKey attKey, int value) => m_baseAttributes[attKey] = value;

        public int GetCurrentAttribute(AttributeKey attKey) => m_baseAttributes.TryGetValue(attKey, out var value)
            ? value
            : throw new ArgumentException($"Requested attribute [{attKey}] was never set.", nameof(attKey));

        public void AddLayeredEffect(LayeredEffectDefinition effect)
        {
            throw new NotImplementedException();
        }

        public void ClearLayeredEffects()
        {
            throw new NotImplementedException();
        }
    }
}