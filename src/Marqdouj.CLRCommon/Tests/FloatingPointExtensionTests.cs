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

        #region Using Options

        [TestMethod]
        public void FloatingPointExtensions_ToStringFormat_Options()
        {
            // Arrange
            double d = 1234567.89;
            FloatingPointToStringFormatOptions optN = new(); // { Format = "N2" } is the default
            FloatingPointToStringFormatOptions optF = new() { Format = "F2" };

            // Act
            string n2 = d.ToStringFormat(optN);
            string f2 = d.ToStringFormat(optF);

            // Assert
            Assert.AreEqual("1,234,567.89", n2);
            Assert.AreEqual("1234567.89", f2);
        }

        [TestMethod]
        public void FloatingPointExtensions_ToStringFormat_TruncateZeros_Options()
        {
            // Arrange
            double d = 1234567.00;
            // { Format = "N2" } is the default
            FloatingPointToStringFormatOptions optN = new() { TruncateZeros = true }; 
            FloatingPointToStringFormatOptions optF = new() { Format = "F2", TruncateZeros = true, TruncateFormat = "F0" };
            FloatingPointToStringFormatOptions optNF = new() { TruncateZeros = true, TruncateFormat = "F0" };

            // Act
            string n2 = d.ToStringFormat(optN);
            string f2 = d.ToStringFormat(optF);
            string nf2 = d.ToStringFormat(optNF); //Shouldn't happen, but just in case

            // Assert
            Assert.AreEqual("1,234,567", n2);
            Assert.AreEqual("1234567", f2);
            Assert.AreEqual("1234567", nf2);
        }

        #endregion
    }
}
