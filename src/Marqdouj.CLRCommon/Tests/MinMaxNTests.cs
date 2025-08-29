using Marqdouj.CLRCommon;
using System.Text.Json;

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
        public void MinMaxN_Constructor_Json()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50);
            string json = JsonSerializer.Serialize(minMaxN);
            MinMaxN<int>? minMaxN2 = JsonSerializer.Deserialize<MinMaxN<int>>(json);
            Assert.IsNotNull(minMaxN2);
            Assert.AreEqual(minMaxN.Min, minMaxN2.Min);
            Assert.AreEqual(minMaxN.Max, minMaxN2.Max);
            Assert.AreEqual(minMaxN.Value, minMaxN2.Value);
        }

        [TestMethod]
        public void MinMaxN_ToString()
        {
            MinMaxN<int> minMaxN = new(0, 100, 25);
            Assert.AreEqual("25", minMaxN.ToString());
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

        #region StringValue

        [TestMethod]
        public void MinMaxN_StringValue_Int()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "10";

            Assert.AreEqual(10, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_StringValue_Int_OverMax()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "101";

            Assert.AreEqual(100, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_StringValue_Int_BadValue()
        {
            MinMaxN<int> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "My 10";

            Assert.AreEqual(50, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_StringValue_Double()
        {
            MinMaxN<double> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "10.5";

            Assert.AreEqual(10.5, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_StringValue_Double_OverMax()
        {
            MinMaxN<double> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "100.5";

            Assert.AreEqual(100, minMaxN.Value);
        }

        [TestMethod]
        public void MinMaxN_StringValue_Double_BadValue()
        {
            MinMaxN<double> minMaxN = new(0, 100, 50);

            minMaxN.StringValue = "My 10.5";

            Assert.AreEqual(50, minMaxN.Value);
        }
        #endregion
    }
}
