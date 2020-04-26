using NUnit.Framework;

namespace SByteDev.Common.Extensions.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestFixture]
        public class WhenIsNullOrEmptyCalled
        {
            [Test]
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase("string")]
            public void ShouldReturnIsNullOrEmptyResult(string input)
            {
                Assert.AreEqual(string.IsNullOrEmpty(input), input.IsNullOrEmpty());
            }
        }

        [TestFixture]
        public class WhenNullOrWhiteSpaceCalled
        {
            [Test]
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase("string")]
            public void ShouldReturnIsNullOrWhiteSpaceResult(string input)
            {
                Assert.AreEqual(string.IsNullOrWhiteSpace(input), input.IsNullOrWhiteSpace());
            }
        }
    }
}