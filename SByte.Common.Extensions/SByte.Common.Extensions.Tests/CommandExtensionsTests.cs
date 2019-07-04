using System.Windows.Input;
using NSubstitute;
using NUnit.Framework;

namespace SByte.Common.Extensions.Tests
{
    [TestFixture]
    public class CommandExtensionsTests
    {
        [TestFixture]
        public class WhenSafeCanExecuteCalled
        {
            [TestFixture]
            public class AndTheCommandIsNull
            {
                [Test]
                public void ExceptionsShouldNotBeThrown()
                {
                    const int parameter = 1;
                    Assert.DoesNotThrow(() => default(ICommand).SafeCanExecute(parameter));
                }

                [Test]
                public void ExecuteShouldNotBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    command.SafeCanExecute(parameter);

                    command.DidNotReceive().Execute(Arg.Any<object>());
                }
            }

            [TestFixture]
            public class AndTheCommandIsNotExecutable
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    Assert.False(command.SafeCanExecute(parameter));
                }

                [Test]
                public void ExecuteShouldNotBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    command.SafeCanExecute(parameter);

                    command.DidNotReceive().Execute(Arg.Any<object>());
                }
            }

            [TestFixture]
            public class AndTheCommandIsExecutable
            {
                [Test]
                public void ShouldReturnTrue()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();
                    command.CanExecute(Arg.Any<object>()).Returns(true);

                    Assert.True(command.SafeCanExecute(parameter));
                }

                [Test]
                public void ExecuteShouldNotBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();
                    command.CanExecute(Arg.Any<object>()).Returns(true);

                    command.SafeCanExecute(parameter);

                    command.DidNotReceive().Execute(Arg.Any<object>());
                }
            }
        }

        [TestFixture]
        public class WhenSafeExecuteCalled
        {
            [TestFixture]
            public class AndTheCommandIsNull
            {
                [Test]
                public void ExceptionsShouldNotBeThrown()
                {
                    const int parameter = 1;

                    Assert.DoesNotThrow(() => default(ICommand).SafeExecute(parameter));
                }

                [Test]
                public void ExecuteShouldNotBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    command.SafeExecute(parameter);

                    command.DidNotReceive().Execute(Arg.Any<object>());
                }
            }

            [TestFixture]
            public class AndTheCommandIsNotExecutable
            {
                [Test]
                public void ExecuteShouldNotBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    command.SafeExecute(parameter);

                    command.DidNotReceive().Execute(Arg.Any<object>());
                }

                [Test]
                public void ShouldReturnFalse()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();

                    Assert.False(command.SafeExecute(parameter));
                }
            }

            [TestFixture]
            public class AndTheCommandIsExecutable
            {
                [Test]
                public void ExecuteShouldBeCalled()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();
                    command.CanExecute(Arg.Any<object>()).Returns(true);

                    command.SafeExecute(parameter);

                    command.Received().Execute(Arg.Is(parameter));
                }

                [Test]
                public void ShouldReturnTrue()
                {
                    const int parameter = 1;
                    var command = Substitute.For<ICommand>();
                    command.CanExecute(Arg.Any<object>()).Returns(true);

                    Assert.True(command.SafeExecute(parameter));
                }
            }
        }
    }
}