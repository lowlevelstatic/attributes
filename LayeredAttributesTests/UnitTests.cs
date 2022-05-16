using NUnit.Framework;
using LayeredAttributes;

namespace LayeredAttributesTests
{
    public class Tests
    {
        [Test]
        public void GetCurrentAttribute_Uninitialized_ThrowsException()
        {
            // Arrange
            var attributes = new SampleLayeredAttributes();

            // Act
            
            // Assert
            Assert.That(() => attributes.GetCurrentAttribute(AttributeKey.Power), Throws.ArgumentException);
        }
        
        [Test]
        public void GetCurrentAttribute_WithBaseAttribute_ReturnsBaseAttribute()
        {
            // Arrange
            var attributes = CreateWaterElemental();

            // Act
            
            // Assert
            Assert.AreEqual(5, attributes.GetCurrentAttribute(AttributeKey.Power));
            Assert.AreEqual(4, attributes.GetCurrentAttribute(AttributeKey.Toughness));
        }
        
        [Test]
        public void AddLayeredEffect_WithSets_ReturnsOverride()
        {
            // Arrange
            var attributes = CreateWaterElemental();
            
            // Act
            attributes.AddLayeredEffect(CreatePowerSet());
            attributes.AddLayeredEffect(CreateToughnessSet());
            
            // Assert
            Assert.AreEqual(0, attributes.GetCurrentAttribute(AttributeKey.Power));
            Assert.AreEqual(1, attributes.GetCurrentAttribute(AttributeKey.Toughness));
        }

        [Test]
        public void AddLayeredEffect_WithAdds_ReturnsTotal()
        {
            // Arrange
            var attributes = CreateWaterElemental();
            
            // Act
            attributes.AddLayeredEffect(CreatePowerAdd());
            attributes.AddLayeredEffect(CreateToughnessAdd());
            
            // Assert
            Assert.AreEqual(7, attributes.GetCurrentAttribute(AttributeKey.Power));
            Assert.AreEqual(5, attributes.GetCurrentAttribute(AttributeKey.Toughness));
        }
        
        [Test]
        public void AddLayeredEffect_WithSubs_ReturnsTotal()
        {
            // Arrange
            var attributes = CreateWaterElemental();
            
            // Act
            attributes.AddLayeredEffect(CreatePowerSub());
            attributes.AddLayeredEffect(CreateToughnessSub());
            
            // Assert
            Assert.AreEqual(3, attributes.GetCurrentAttribute(AttributeKey.Power));
            Assert.AreEqual(2, attributes.GetCurrentAttribute(AttributeKey.Toughness));
        }
        
        private static SampleLayeredAttributes CreateWaterElemental()
        {
            var attributes = new SampleLayeredAttributes();
            attributes.SetBaseAttribute(AttributeKey.Power, 5);
            attributes.SetBaseAttribute(AttributeKey.Toughness, 4);
            return attributes;
        }

        private static LayeredEffectDefinition CreatePowerSet() => new()
        {
            Attribute = AttributeKey.Power,
            Operation = EffectOperation.Set,
            Modification = 0,
            Layer = 0
        };
        
        private static LayeredEffectDefinition CreateToughnessSet() => new()
        {
            Attribute = AttributeKey.Toughness,
            Operation = EffectOperation.Set,
            Modification = 1,
            Layer = 0
        };
        
        private static LayeredEffectDefinition CreatePowerAdd() => new()
        {
            Attribute = AttributeKey.Power,
            Operation = EffectOperation.Add,
            Modification = 2,
            Layer = 0
        };
        
        private static LayeredEffectDefinition CreateToughnessAdd() => new()
        {
            Attribute = AttributeKey.Toughness,
            Operation = EffectOperation.Add,
            Modification = 1,
            Layer = 0
        };

        private static LayeredEffectDefinition CreatePowerSub() => new()
        {
            Attribute = AttributeKey.Power,
            Operation = EffectOperation.Subtract,
            Modification = 2,
            Layer = 0
        };
        
        private static LayeredEffectDefinition CreateToughnessSub() => new()
        {
            Attribute = AttributeKey.Toughness,
            Operation = EffectOperation.Subtract,
            Modification = 2,
            Layer = 0
        };
    }
}