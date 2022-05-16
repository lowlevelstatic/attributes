using System;
using System.Collections.Generic;
using System.Linq;

namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        private readonly Dictionary<AttributeKey, int> m_baseAttributes = new();
        private readonly List<LayeredEffectDefinition> m_effectDefinitions = new();

        public void SetBaseAttribute(AttributeKey attKey, int value) => m_baseAttributes[attKey] = value;

        public int GetCurrentAttribute(AttributeKey attKey)
        {
            var baseAttribute = m_baseAttributes.TryGetValue(attKey, out var value)
                ? value
                : throw new ArgumentException($"Requested attribute [{attKey}] was never set.", nameof(attKey));

            return m_effectDefinitions
                .Where(definition => definition.Attribute == attKey)
                .Select(definition => definition.Modification)
                .Aggregate(baseAttribute, (attribute, modification) => attribute + modification);
        }

        public void AddLayeredEffect(LayeredEffectDefinition effect) => m_effectDefinitions.Add(effect);

        public void ClearLayeredEffects()
        {
            throw new NotImplementedException();
        }
    }
}