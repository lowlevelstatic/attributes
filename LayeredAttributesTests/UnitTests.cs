using NUnit.Framework;
using LayeredAttributes;

namespace LayeredAttributesTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

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
            var attributes = new SampleLayeredAttributes();

            // Act
            attributes.SetBaseAttribute(AttributeKey.Power, 5);
            attributes.SetBaseAttribute(AttributeKey.Toughness, 4);
            
            // Assert
            Assert.AreEqual(5, attributes.GetCurrentAttribute(AttributeKey.Power));
            Assert.AreEqual(4, attributes.GetCurrentAttribute(AttributeKey.Toughness));
        }
    }
}