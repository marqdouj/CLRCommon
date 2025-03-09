using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class MinMaxNTests
    {
        [TestMethod]
        public void MinMaxN_Constructor()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50);
            Assert.AreEqual(0, minMaxN.Min);
            Assert.AreEqual(100, minMaxN.Max);
            Assert.AreEqual(50, minMaxN.Value);
        }

        [TestMethod] public void MinMaxN_Constructor_NoValue()
        {
            MinMaxN<int> minMaxN = new(0, 100);
            Assert.AreEqual(0, minMaxN.Min);
            Assert.AreEqual(100, minMaxN.Max);
            Assert.AreEqual(0, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_Value()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50)
            {
                Value = 75
            };
            Assert.AreEqual(75, minMaxN.Value);
            minMaxN.Value = 101;
            Assert.AreEqual(100, minMaxN.Value);
            minMaxN.Value = -1;
            Assert.AreEqual(0, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_Width_Int()
        {
            MinMaxN<int> minMaxN = new(0, 100);
            Assert.AreEqual(100, minMaxN.Width);
        }

        [TestMethod]
        public void MinMaxN_Center_Int()
        {
            MinMaxN<int> minMaxN = new(0, 100);
            Assert.AreEqual(50, minMaxN.Center);
        }

        [TestMethod]
        public void MinMaxN_Width_Double()
        {
            MinMaxN<double> minMaxN = new(29.35, 48.83);
            Assert.AreEqual("19.48", minMaxN.Width.ToString("0.00"));
        }

        [TestMethod]
        public void MinMaxN_Center_Double()
        {
            MinMaxN<double> minMaxN = new(29.35, 48.83);
            Assert.AreEqual(39.09, minMaxN.Center);
        }
    }
}
