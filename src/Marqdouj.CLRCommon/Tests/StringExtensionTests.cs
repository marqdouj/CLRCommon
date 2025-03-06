using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class StringExtensionTests
    {
        [TestMethod]
        public void Strings_Truncate_MaxLengthEqual()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length;
            const string suffix = StringExtensions.ELLIPSIS;
            const string expected = value;
            var expectedLength = value.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.IsTrue(result!.Length == expectedLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthLess()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 5;
            const string suffix = StringExtensions.ELLIPSIS;
            const string expected = "This " + StringExtensions.ELLIPSIS;
            var expectedLength = maxLength + suffix.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.IsTrue(result!.Length == expectedLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthMore()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length + 1;
            const string suffix = StringExtensions.ELLIPSIS;
            const string expected = value;
            var expectedLength = value.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.IsTrue(result!.Length == expectedLength);
            Assert.AreEqual(expected, result);
        }
    }
}
