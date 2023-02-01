using Shouldly;
using System;
using System.Linq;
using TestNinja.Fundamentals;
using Xunit;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.Xunit.Tests
{
    public class MathTests
    {
        private Math _math;

        public MathTests()
        {
            _math = new Math();
        }

        [Fact]
        public void Add_WhenCalled_ShouldReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);
            result.ShouldBe(3);
        }

        [Theory]
        [InlineData(2,1,2)]
        [InlineData(1,2,2)]
        [InlineData(1,1,1)]
        public void Max_WhenCalled_ShouldReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void GetOddNumbers_LimitIsGreaterThanZero_ShouldReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            result.ShouldBeUnique();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(3);
            result.ShouldBe(new[] {1,3,5});
            result.ShouldBeInOrder();
        }
    }
}
