using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class StringExtensionTests
    {
        #region ToCrLf

        [TestMethod]
        public void Strings_ToCrLf_AtStart_CRLF()
        {
            //Arrange
            const string value = "\r\nThis is a test.";
            const string expected = "\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_CRLF()
        {
            //Arrange
            const string value = "This is\r\n a test.";
            const string expected = "This is\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_CRLF()
        {
            //Arrange
            const string value = "This is a test.\r\n";
            const string expected = "This is a test.\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtStart_LF()
        {
            //Arrange
            const string value = "\nThis is a test.";
            const string expected = "\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_LF()
        {
            //Arrange
            const string value = "This is\n a test.";
            const string expected = "This is\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_LF()
        {
            //Arrange
            const string value = "This is a test.\n";
            const string expected = "This is a test.\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtStart_MIXED()
        {
            //Arrange
            const string value = "\r\n\nThis is a test.";
            const string expected = "\r\n\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_MIXED()
        {
            //Arrange
            const string value = "This is\r\n\n a test.";
            const string expected = "This is\r\n\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_MIXED()
        {
            //Arrange
            const string value = "This is a test.\r\n\n";
            const string expected = "This is a test.\r\n\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_NoLineFeed()
        {
            //Arrange
            const string value = "This is a test.";
            const string expected = "This is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Left

        [TestMethod]
        public void Strings_Left_MaxLengthEqual()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length;
            const string expected = value;
            //Act
            var result = value.Left(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_MaxLengthLess()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 5;
            const string expected = "This ";
            //Act
            var result = value.Left(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_MaxLengthGreater() 
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length + 1;
            const string expected = value;
            //Act
            var result = value.Left(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_MaxLengthZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 0;
            const string expected = "";
            //Act
            var result = value.Left(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_MaxLengthLessThanZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = -1;
            //Act/Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => value.Left(maxLength));
        }

        #endregion

        #region Right

        [TestMethod]
        public void Strings_Right_MaxLengthEqual()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length;
            const string expected = value;
            //Act
            var result = value.Right(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Right_MaxLengthLess()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 5;
            const string expected = "test.";
            //Act
            var result = value.Right(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Right_MaxLengthGreater()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length + 1;
            const string expected = value;
            //Act
            var result = value.Right(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Right_MaxLengthZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 0;
            const string expected = "";
            //Act
            var result = value.Right(maxLength);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Right_MaxLengthLessThanZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = -1;
            //Act/Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => value.Right(maxLength));
        }

        #endregion

        #region ToTitleCase

        [TestMethod]
        public void Strings_ToTitleCase()
        {
            //Arrange
            const string value = "this is a test.";
            const string expected = "This Is A Test.";
            //Act
            var result = value.ToTitleCase();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToTitleCase_WithAllUpperWord()
        {
            //Arrange
            const string value = "this is a TEST.";
            const string expected = "This Is A TEST.";
            //Act
            var result = value.ToTitleCase();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToTitleCase_NoConversion()
        {
            //Arrange
            const string value = "This Is A Test.";
            const string expected = "This Is A Test.";
            //Act
            var result = value.ToTitleCase();
            //Assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Truncate

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

        [TestMethod]
        public void Strings_Truncate_MaxLengthZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 0;
            const string suffix = StringExtensions.ELLIPSIS;
            const string expected = StringExtensions.ELLIPSIS;
            var expectedLength = StringExtensions.ELLIPSIS.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.IsTrue(result!.Length == expectedLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthLessThanZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = -1;
            const string suffix = StringExtensions.ELLIPSIS;

            //Act/Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => value.Truncate(maxLength, suffix));
        }

        #endregion
    }
}
