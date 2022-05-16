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
    }
}