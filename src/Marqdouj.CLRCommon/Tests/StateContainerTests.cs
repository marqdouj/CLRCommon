using Marqdouj.CLRCommon;

namespace Tests
{
    [TestClass]
    public sealed class StateContainerTests
    {
        [TestMethod]
        public void StateContainer_SuppressNotifications_False()
        {
            //arrange
            var state = new TestState { SuppressNotifications = false };

            //act 
            state.Name = "Test";

            //assert
            Assert.AreEqual(1, state.PropertyChangedFired);
            Assert.AreEqual(1, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_SuppressNotifications_True()
        {
            //arrange
            var state = new TestState { SuppressNotifications = true };

            //act 
            state.Name = "Test";

            //assert
            Assert.AreEqual(0, state.PropertyChangedFired);
            Assert.AreEqual(0, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_MultipleValues_SuppressNotifications()
        {
            //arrange
            var state = new TestState { SuppressNotifications = true };

            //act 
            state.Name = "Test1";
            state.Name = "Test2";
            state.Name = "Test3";

            //assert
            Assert.AreEqual(0, state.PropertyChangedFired);
            Assert.AreEqual(0, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_MultipleValues_AllNotifications()
        {
            //arrange
            var state = new TestState { SuppressNotifications = false };

            //act 
            state.Name = "Test1";
            state.Name = "Test2";
            state.Name = "Test3";

            //assert
            Assert.AreEqual(3, state.PropertyChangedFired);
            Assert.AreEqual(3, state.StateChangedFired);
        }

        private class TestState : StateContainer, IDisposable
        {
            public TestState()
            {
                StateChanged += TestState_StateChanged;
                PropertyChanged += TestState_PropertyChanged;
            }

            private void TestState_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                PropertyChangedFired++;
            }

            private void TestState_StateChanged(string obj)
            {
                StateChangedFired++;
            }

            #region Name
            private string? name;
            public string? Name { get => name; set => SetValue(ref name, value); }
            #endregion

            public int StateChangedFired { get; private set; }
            public int PropertyChangedFired { get; private set; }

            public void Dispose()
            {
                StateChanged -= TestState_StateChanged;
                PropertyChanged -= TestState_PropertyChanged;
            }
        }
    }
}
