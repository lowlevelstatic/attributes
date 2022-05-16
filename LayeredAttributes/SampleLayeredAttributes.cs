using System;
using System.Collections.Generic;
using System.Linq;

namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        private readonly BaseAttributes m_baseAttributes = new();
        private readonly List<LayeredEffectDefinition> m_effectDefinitions = new();

        public void SetBaseAttribute(AttributeKey attKey, int value) => m_baseAttributes.SetAttribute(attKey, value);

        public int GetCurrentAttribute(AttributeKey attKey) => m_effectDefinitions
            .Where(definition => definition.Attribute == attKey)
            .Aggregate(m_baseAttributes.GetAttribute(attKey), LayeredAttributesUtils.ApplyLayeredEffect);

        public void AddLayeredEffect(LayeredEffectDefinition effect) => m_effectDefinitions.Add(effect);

        public void ClearLayeredEffects()
        {
            throw new NotImplementedException();
        }
    }
}