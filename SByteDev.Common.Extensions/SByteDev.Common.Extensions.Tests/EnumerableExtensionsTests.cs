using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace SByteDev.Common.Extensions.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public class EnumerableExtensionsTests
    {
        [TestFixture]
        public class WhenIndexOfCalled
        {
            [TestFixture]
            public class AndTheEnumerableIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => default(IEnumerable).IndexOf(null));
                }
            }

            [TestFixture]
            public class AndTheEqualityComparerIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => Substitute.For<IEnumerable>().IndexOf(null, null));
                }
            }

            [Test]
            public void EqualityComparerShouldBeUsed()
            {
                var equalityComparer = Substitute.For<IEqualityComparer>();
                equalityComparer.Equals(Arg.Any<object>(), Arg.Any<object>()).Returns(args => Equals(args[0], args[1]));

                var enumerable = Enumerable.Range(0, 10);

                var result = enumerable.IndexOf(5, equalityComparer);

                equalityComparer.Received().Equals(Arg.Any<object>(), Arg.Any<object>());

                Assert.AreEqual(5, result);
            }
        }

        [TestFixture]
        public class WhenGenericIndexOfCalled
        {
            [TestFixture]
            public class AndTheEnumerableIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => default(IEnumerable<object>).IndexOf(null));
                }
            }

            [TestFixture]
            public class AndTheEqualityComparerIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<object>().IndexOf(null, null));
                }
            }

            [Test]
            public void EqualityComparerShouldBeUsed()
            {
                var equalityComparer = Substitute.For<IEqualityComparer<int>>();
                equalityComparer.Equals(Arg.Any<int>(), Arg.Any<int>()).Returns(args => Equals(args[0], args[1]));

                var enumerable = Enumerable.Range(0, 10);

                var result = enumerable.IndexOf(5, equalityComparer);

                equalityComparer.Received().Equals(Arg.Any<int>(), Arg.Any<int>());

                Assert.AreEqual(5, result);
            }
        }

        [TestFixture]
        public class WhenTakeCalled
        {
            [TestFixture]
            public class AndTheEnumerableIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => default(IEnumerable<object>).Take(0, 0));
                }
            }

            [TestFixture]
            public class AndTheEnumerableIsList
            {
                [Test]
                [TestCase(0, 0)]
                [TestCase(0, 1)]
                [TestCase(3, 0)]
                [TestCase(3, 3)]
                public void CorrectSubEnumerableShouldBeReturned(int index, int length)
                {
                    var enumerable = Enumerable.Range(0, 10).ToList();

                    var result = enumerable.Take(index, length);

                    Assert.AreEqual(enumerable.ToList().GetRange(index, length), result);
                }
            }

            [Test]
            [TestCase(0, 0)]
            [TestCase(0, 1)]
            [TestCase(3, 0)]
            [TestCase(3, 3)]
            public void CorrectSubEnumerableShouldBeReturned(int index, int length)
            {
                var enumerable = Enumerable.Range(0, 10);

                var result = enumerable.Take(index, length);

                Assert.AreEqual(enumerable.ToList().GetRange(index, length), result);
            }
        }

        [TestFixture]
        public class WhenIsNullOrEmptyCalled
        {
            [TestFixture]
            public class AndTheEnumerableIsNull
            {
                [Test]
                public void TrueShouldBeReturned()
                {
                    Assert.IsTrue(default(IEnumerable).IsNullOrEmpty());
                }
            }

            [TestFixture]
            public class AndTheEnumerableCountIsZero
            {
                [Test]
                public void TrueShouldBeReturned()
                {
                    Assert.IsTrue(Enumerable.Empty<int>().IsNullOrEmpty());
                }
            }

            [TestFixture]
            public class AndTheEnumerableCountIsNotZero
            {
                [Test]
                public void FalseShouldBeReturned()
                {
                    Assert.IsFalse(Enumerable.Range(0, 10).IsNullOrEmpty());
                }
            }
        }

        [TestFixture]
        public class WhenCountCalled
        {
            [TestFixture]
            public class AndTheEnumerableIsNull
            {
                [Test]
                public void ExceptionShouldBeThrown()
                {
                    Assert.Throws<ArgumentNullException>(() => default(IEnumerable<object>).Count());
                }
            }

            [TestFixture]
            public class AndTheEnumerableIsCollection
            {
                [Test]
                [TestCase(0)]
                [TestCase(10)]
                public void FalseShouldBeReturned(int count)
                {
                    var enumerable = Enumerable.Range(0, count).ToList();

                    Assert.AreEqual(count, enumerable.Count());
                }
            }

            [Test]
            [TestCase(0)]
            [TestCase(10)]
            public void FalseShouldBeReturned(int count)
            {
                var enumerable = Enumerable.Range(0, count) as IEnumerable;

                Assert.AreEqual(count, enumerable.Count());
            }
        }
    }
}