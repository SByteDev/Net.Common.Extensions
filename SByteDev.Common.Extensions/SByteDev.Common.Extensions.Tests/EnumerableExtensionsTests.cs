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
        }

        [TestFixture]
        public class WhenIsNullOrEmptyCalled
        {
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
        }
    }
}