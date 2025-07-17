using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class EnumListTests
    {
        private enum Test1
        {
            One, Two, Three, Four,
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValue()
        {
            //Arrange
            var items = new EnumList<Test1>();

            //Act
            items.AddValue(Test1.One);
            items.AddValue(Test1.One);
            var count = items.Count;

            //Assert
            Assert.AreEqual(1, count);
            Assert.IsTrue(items.Items.Contains(Test1.One));
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_Constructor()
        {
            //Arrange
            var items = new EnumList<Test1>([Test1.One, Test1.Four, Test1.One, Test1.Four]);

            //Act
            var count = items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(Test1.One));
            Assert.IsTrue(items.Items.Contains(Test1.Four));
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_List()
        {
            //Arrange
            var items = new EnumList<Test1>();

            //Act
            items.AddValues(new List<Test1> { Test1.One, Test1.Four, Test1.One, Test1.Four });
            var count = items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(Test1.One));
            Assert.IsTrue(items.Items.Contains(Test1.Four));
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_List_Empty()
        {
            //Arrange
            var items = new EnumList<Test1>();
            List<Test1>? list = null;

            //Act
            items.AddValues(list!);
            var count = items.Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_Params()
        {
            //Arrange
            var items = new EnumList<Test1>();

            //Act
            items.AddValues(Test1.One, Test1.Four, Test1.One, Test1.Four);
            var count = items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(Test1.One));
            Assert.IsTrue(items.Items.Contains(Test1.Four));
        }
    }
}
