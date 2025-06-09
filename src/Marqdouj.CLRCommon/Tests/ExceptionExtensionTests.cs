using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class ExceptionExtensionTests
    {
        [TestMethod]
        public void ExceptionExtension_ToMessage_SingleException()         
        {
            //Arrange
            const string message = "This is a single exception message.";
            var ex = new Exception(message);

            //Act
            var result = ex.ToMessage();
            var resultChar = ex.ToMessage('\n');
            var resultString = ex.ToMessage("\n");

            //Assert
            Assert.AreEqual(message, result, "default");
            Assert.AreEqual(message, resultChar, "char sep");
            Assert.AreEqual(message, resultString, "string sep");
        }

        [TestMethod]
        public void ExceptionExtension_ToMessage_InnerExceptions()
        {
            //Arrange
            const string message1 = "Outer Exception.";
            const string message2 = "Inner Exception.";
            const string message3 = "Inner Inner Exception.";
            var ex = new Exception(message1, new Exception(message2, new Exception(message3)));
            var x = new AggregateException("", ex);
            var expected = string.Join('\n', message1, message2, message3);
            var expectedChar = expected;
            var expectedString = string.Join("\n", message1, message2, message3);

            //Act
            var result = ex.ToMessage();
            var resultChar = ex.ToMessage('\n');
            var resultString = ex.ToMessage("\n");

            //Assert
            Assert.AreEqual(expected, result, "default");
            Assert.AreEqual(expectedChar, resultChar, "char sep");
            Assert.AreEqual(expectedString, resultString, "string sep");
        }

        [TestMethod]
        public void ExceptionExtension_ToMessage_AggregateException()
        {
            //Arrange
            const string message = "This is an AggregateException.";
            const string message1 = "Outer Exception.";
            const string message2 = "Inner Exception.";
            const string message3 = "Inner Inner Exception.";
            var ex1 = new Exception(message1);
            var ex2 = new Exception(message2);
            var ex3 = new Exception(message3);
            var ex = new AggregateException(message, ex1, ex2, ex3);
            var expected = string.Join('\n', message1, message2, message3);
            var expectedChar = expected;
            var expectedString = string.Join("\n", message1, message2, message3);

            //Act
            var result = ex.ToMessage();
            var resultChar = ex.ToMessage('\n');
            var resultString = ex.ToMessage("\n");

            //Assert
            Assert.AreEqual(expected, result, "default");
            Assert.AreEqual(expectedChar, resultChar, "char sep");
            Assert.AreEqual(expectedString, resultString, "string sep");
        }
    }
}
