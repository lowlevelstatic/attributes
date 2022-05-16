using System.Collections.Generic;
using System.Linq;

namespace LayeredAttributes
{
    public class LayeredEffects
    {
        private readonly List<LayeredEffectDefinition> m_definitions = new();

        public void AddEffect(LayeredEffectDefinition effect)
        {
            int index = m_definitions.FindIndex(definition => definition.Layer > effect.Layer);

            if (index > -1)
            {
                m_definitions.Insert(index, effect);
                return;
            }

            m_definitions.Add(effect);
        }

        public int ApplyEffects(AttributeKey attKey, int attribute) => m_definitions
            .Where(definition => definition.Attribute == attKey)
            .Aggregate(attribute, LayeredAttributesUtils.ApplyLayeredEffect);

        public void Clear() => m_definitions.Clear();
    }
}