using Marqdouj.CLRCommon;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public sealed class ObjectExtensionsNumericTests
    {
        #region Byte

        [TestMethod]
        public void Object_IsNumber_Byte_False()
        {
            //Arrange
            const byte ba = (byte)'a';
            const byte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumber(false);
            var b1IsNumber = b1.IsNumber(false);

            //Assert
            Assert.IsFalse(baIsNumber);
            Assert.IsFalse(b1IsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Byte_True()
        {
            //Arrange
            const byte ba = (byte)'a';
            const byte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumber(true);
            var b1IsNumber = b1.IsNumber(true);

            //Assert
            Assert.IsTrue(baIsNumber);
            Assert.IsTrue(b1IsNumber);
        }

        #endregion

        #region SByte

        [TestMethod]
        public void Object_IsNumber_SByte_False()
        {
            //Arrange
            const sbyte ba = (sbyte)'a';
            const sbyte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumber(false);
            var b1IsNumber = b1.IsNumber(false);

            //Assert
            Assert.IsFalse(baIsNumber);
            Assert.IsFalse(b1IsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_SByte_True()
        {
            //Arrange
            const sbyte ba = (sbyte)'a';
            const sbyte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumber(true);
            var b1IsNumber = b1.IsNumber(true);

            //Assert
            Assert.IsTrue(baIsNumber);
            Assert.IsTrue(b1IsNumber);
        }

        #endregion

        [TestMethod]
        public void Object_IsNumber()
        {
            //Arrange
            const UInt16 a = 1;
            const UInt32 b = 2;
            const UInt64 c = 3;
            const Int16 d = 4;
            const Int32 e = 5;
            const Int64 f = 6;
            const Decimal g = 7;
            const Double h = 8;
            const Single j = 9;

            //Act
            var aIsNumber = a.IsNumber();
            var bIsNumber = b.IsNumber();
            var cIsNumber = c.IsNumber();
            var dIsNumber = d.IsNumber();
            var eIsNumber = e.IsNumber();
            var fIsNumber = f.IsNumber();
            var gIsNumber = g.IsNumber();
            var hIsNumber = h.IsNumber();
            var jIsNumber = j.IsNumber();

            //Assert
            Assert.IsTrue(aIsNumber);
            Assert.IsTrue(bIsNumber);
            Assert.IsTrue(cIsNumber);
            Assert.IsTrue(dIsNumber);
            Assert.IsTrue(eIsNumber);
            Assert.IsTrue(fIsNumber);
            Assert.IsTrue(gIsNumber);
            Assert.IsTrue(hIsNumber);
            Assert.IsTrue(jIsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_False()
        {
            //Arrange
            const UInt16 a = 1;
            const UInt32 b = 2;
            const UInt64 c = 3;
            const Int16 d = 4;
            const Int32 e = 5;
            const Int64 f = 6;
            const Decimal g = 7;
            const Double h = 8;
            const Single j = 9;

            //Act
            var aIsNumber = a.IsNumber(false);
            var bIsNumber = b.IsNumber(false);
            var cIsNumber = c.IsNumber(false);
            var dIsNumber = d.IsNumber(false);
            var eIsNumber = e.IsNumber(false);
            var fIsNumber = f.IsNumber(false);
            var gIsNumber = g.IsNumber(false);
            var hIsNumber = h.IsNumber(false);
            var jIsNumber = j.IsNumber(false);

            //Assert
            Assert.IsTrue(aIsNumber);
            Assert.IsTrue(bIsNumber);
            Assert.IsTrue(cIsNumber);
            Assert.IsTrue(dIsNumber);
            Assert.IsTrue(eIsNumber);
            Assert.IsTrue(fIsNumber);
            Assert.IsTrue(gIsNumber);
            Assert.IsTrue(hIsNumber);
            Assert.IsTrue(jIsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_String()
        {
            //Arrange
            object value = "1";

            //Act
            var isNumber = value.IsNumber();

            //Assert
            Assert.IsFalse(isNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Null()
        {
            //Arrange
            object? value = null;

            //Act
            var isNumber = value.IsNumber();

            //Assert
            Assert.IsFalse(isNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Class()
        {
            //Arrange
            var item = new TestIsNumber();

            //Act
            var isNumber = item.IsNumber();

            //Assert
            Assert.IsFalse(isNumber);
        }

        private class TestIsNumber {}
    }
}
