using System;

namespace LayeredAttributes
{
    public static class LayeredAttributesUtils
    {
        public static int ApplyLayeredEffect(int attribute, LayeredEffectDefinition definition) =>
            definition.Operation switch
            {
                EffectOperation.Invalid => throw new ArgumentException(
                    $"Invalid operation {definition.Operation}", nameof(definition.Operation)),
                EffectOperation.Set => definition.Modification,
                EffectOperation.Add => attribute + definition.Modification,
                EffectOperation.Subtract => attribute - definition.Modification,
                EffectOperation.Multiply => attribute * definition.Modification,
                EffectOperation.BitwiseOr => attribute | definition.Modification,
                EffectOperation.BitwiseAnd => attribute & definition.Modification,
                EffectOperation.BitwiseXor => attribute ^ definition.Modification,
                _ => throw new ArgumentOutOfRangeException(
                    $"Invalid operation {definition.Operation}", nameof(definition.Operation))
            };
    }
}