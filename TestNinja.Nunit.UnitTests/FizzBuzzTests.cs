using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void Setup()
        {
            _fizzBuzz= new FizzBuzz();
        }

        [Test]
        public void GetOutput_DivisibleByZero_ReturnsNumber()
        {
            var result = _fizzBuzz.GetOutput(0);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
