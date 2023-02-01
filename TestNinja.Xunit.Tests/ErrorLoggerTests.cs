using Shouldly;
using System;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.Tests
{

    public class ErrorLoggerTests : IDisposable
    {
        private ErrorLogger _logger;

        public ErrorLoggerTests()
        {
            _logger = new ErrorLogger();
        }

        public void Dispose()
        {
            _logger.Equals(null);
        }

        [Fact]
        public void Log_WhenCalled_ShouldSetTheLastErrorProperty()
        {
            _logger.Log("a");
            var lastError = _logger.LastError;
            lastError.ShouldBe("a");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidError_ShouldThrowArgumentNullException(string error)
        {
            Should.Throw<ArgumentNullException>(() => _logger.Log(error));
        }

        [Fact]
        public void Log_ValidError_ShouldRaiseErrorLogEvent()
        {
            //Declare an empty guid
            var id = Guid.Empty;

            //subscribe to the event and set args to id
            //If the event is successfully raised
            //id will be populated with a new guid
            _logger.ErrorLogged += (sender, args) => { id = args; };

            //Method call
            _logger.Log("a");

            //Assert that we have an guid now.
            id.ShouldNotBe(Guid.Empty);
        }
    }
}
