using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class StringExtensionsNumericTests
    {
        [TestMethod]
        public void Strings_IsNumeric()
        {
            Assert.IsTrue("123".IsNumeric());
            Assert.IsTrue("123.45".IsNumeric());
            Assert.IsTrue("123,45".IsNumeric());
            Assert.IsTrue("123,456.78".IsNumeric());
            Assert.IsFalse("123.456,78".IsNumeric());
            Assert.IsTrue("123,456,789.01".IsNumeric());
            Assert.IsFalse("".IsNumeric());
            Assert.IsFalse(" ".IsNumeric());
            Assert.IsTrue("0".IsNumeric());

            string? nullString = null;
            Assert.IsFalse(nullString.IsNumeric());
        }

        [TestMethod]
        public void Strings_IsPositiveInteger()
        {
            Assert.IsTrue("123".IsPositiveInteger());
            Assert.IsFalse("-123".IsPositiveInteger());
            Assert.IsTrue("0".IsPositiveInteger());
            Assert.IsFalse("".IsPositiveInteger());
            Assert.IsFalse(" ".IsPositiveInteger());

            string? nullString = null;
            Assert.IsFalse(nullString.IsNumeric());
        }
    }
}
