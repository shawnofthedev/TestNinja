using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> stack;

        [SetUp]
        public void SetUp() 
        {
            stack = new Stack<string>();
        }

        [Test]
        public void Push_WithNull_ThrowsArgumentNullException()
        {
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WithValidArgument_AddTheObjectToTheList()
        {
            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObject_ReturnsTopObject()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObject_RemovesTopObject()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnsObjectOnTopOfStack()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTop()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
