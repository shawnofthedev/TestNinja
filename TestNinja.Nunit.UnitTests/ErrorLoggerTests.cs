using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            _logger.Log("a");
            Assert.That(_logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLogEvent()
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
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));

        }
    }
}
