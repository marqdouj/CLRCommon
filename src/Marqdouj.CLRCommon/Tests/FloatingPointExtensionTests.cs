using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class FloatingPointExtensionTests
    {
        [TestMethod]
        public void FloatingPointExtensions_ToStringFormat()
        {
            // Arrange
            double d = 1234567.89;

            // Act
            string n2 = d.ToStringFormat("N2");
            string f2 = d.ToStringFormat("F2");

            // Assert
            Assert.AreEqual("1,234,567.89", n2);
            Assert.AreEqual("1234567.89", f2);
        }

        [TestMethod]
        public void FloatingPointExtensions_ToStringFormat_TruncateZeros()
        {
            // Arrange
            double d = 1234567.00;

            // Act
            string n2 = d.ToStringFormat("N2", true);
            string f2 = d.ToStringFormat("F2", true, "F0");
            string nf2 = d.ToStringFormat("N2", true, "F0"); //Shouldn't happen, but just in case

            // Assert
            Assert.AreEqual("1,234,567", n2);
            Assert.AreEqual("1234567", f2);
            Assert.AreEqual("1234567", nf2);
        }
    }
}
