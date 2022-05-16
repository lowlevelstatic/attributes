namespace LayeredAttributes
{
    public class SampleLayeredAttributes : ILayeredAttributes
    {
        public void SetBaseAttribute(AttributeKey attKey, int value)
        {
            throw new System.NotImplementedException();
        }

        public int GetCurrentAttribute(AttributeKey attKey) => 1;

        public void AddLayeredEffect(LayeredEffectDefinition effect)
        {
            throw new System.NotImplementedException();
        }

        public void ClearLayeredEffects()
        {
            throw new System.NotImplementedException();
        }
    }
}