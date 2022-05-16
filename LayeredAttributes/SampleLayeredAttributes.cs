using System;

namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        private readonly BaseAttributes m_baseAttributes = new();
        private readonly LayeredEffects m_layeredEffects = new();

        public void SetBaseAttribute(AttributeKey attKey, int value) => m_baseAttributes.SetAttribute(attKey, value);

        public int GetCurrentAttribute(AttributeKey attKey) =>
            m_layeredEffects.ApplyEffects(attKey, m_baseAttributes.GetAttribute(attKey));

        public void AddLayeredEffect(LayeredEffectDefinition effect) => m_layeredEffects.AddEffect(effect);

        public void ClearLayeredEffects()
        {
            throw new NotImplementedException();
        }
    }
}