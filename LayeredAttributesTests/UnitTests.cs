using NUnit.Framework;
using LayeredAttributes;

namespace LayeredAttributesTests
{
    public class Tests
    {
        private const AttributeKey DefaultAttributeKey = AttributeKey.Power;
        private const int DefaultAttributeValue = 1;
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCurrentAttribute_byDefault_returnsBaseAttribute()
        {
            // Arrange
            var attributes = new SampleLayeredAttributes();
            
            // Assert
            Assert.AreEqual(DefaultAttributeValue, attributes.GetCurrentAttribute(DefaultAttributeKey));
        }
    }
}