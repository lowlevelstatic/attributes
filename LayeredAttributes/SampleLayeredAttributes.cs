namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        private readonly BaseAttributes m_baseAttributes = new();
        private readonly LayeredEffects m_layeredEffects = new();
        private readonly Memoizer<AttributeKey, int> m_cache = new();

        public void SetBaseAttribute(AttributeKey attKey, int value)
        {
            m_baseAttributes.SetAttribute(attKey, value);
            m_cache.Invalidate(attKey);
        }

        public int GetCurrentAttribute(AttributeKey attKey) => m_cache.Get(attKey, ComputeValue);

        public void AddLayeredEffect(LayeredEffectDefinition effect)
        {
            m_layeredEffects.AddEffect(effect);
            m_cache.Invalidate(effect.Attribute);
        }

        public void ClearLayeredEffects() => m_layeredEffects.Clear();

        private int ComputeValue(AttributeKey attKey) =>
            m_layeredEffects.ApplyEffects(attKey, m_baseAttributes.GetAttribute(attKey));
    }
}