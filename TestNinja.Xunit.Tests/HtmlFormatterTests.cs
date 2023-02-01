using Shouldly;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.Xunit.Tests
{
    public class HtmlFormatterTests
    {
        private HtmlFormatter _formatter;

        public HtmlFormatterTests()
        {
            _formatter = new HtmlFormatter();
        }

        [Fact]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            //so we can ignore any casing
            var result = _formatter.FormatAsBold("abc").ToLower();
            result.ShouldBe("<strong>abc</strong>");
        }

    }
}
