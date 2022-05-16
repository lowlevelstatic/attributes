using System;

namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        public void SetBaseAttribute(AttributeKey attKey, int value)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentAttribute(AttributeKey attKey)
        {
            throw new ArgumentException($"Requested attribute [{attKey}] was never set.", nameof(attKey));
        }

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