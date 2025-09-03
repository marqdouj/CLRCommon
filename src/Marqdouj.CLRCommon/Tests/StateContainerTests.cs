using Marqdouj.CLRCommon;
using System.Security.Cryptography;

namespace Tests
{
    [TestClass]
    public sealed class StateContainerTests
    {
        #region SetValue

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

        #endregion

        #region Manual

        [TestMethod]
        public void StateContainer_SuppressNotifications_Manual_False()
        {
            //arrange
            var state = new TestState { SuppressNotifications = false };

            //act 
            state.Value = true;

            //assert
            Assert.AreEqual(1, state.PropertyChangedFired);
            Assert.AreEqual(1, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_SuppressNotifications_Manual__True()
        {
            //arrange
            var state = new TestState { SuppressNotifications = true };

            //act 
            state.Value = true;

            //assert
            Assert.AreEqual(0, state.PropertyChangedFired);
            Assert.AreEqual(0, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_MultipleValues_SuppressNotifications_Manual()
        {
            //arrange
            var state = new TestState { SuppressNotifications = true };

            //act 
            state.Value = true;
            state.Value = false;
            state.Value = true;

            //assert
            Assert.AreEqual(0, state.PropertyChangedFired);
            Assert.AreEqual(0, state.StateChangedFired);
        }

        [TestMethod]
        public void StateContainer_MultipleValues_AllNotifications_Manual()
        {
            //arrange
            var state = new TestState { SuppressNotifications = false };

            //act 
            state.Value = true;
            state.Value = false;
            state.Value = true;

            //assert
            Assert.AreEqual(3, state.PropertyChangedFired);
            Assert.AreEqual(3, state.StateChangedFired);
        }

        #endregion

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

            #region Value
            private bool _value;
            public bool Value 
            { 
                get => _value;
                set 
                { 
                    if (_value != value)
                    {
                        _value = value;
                        NotifyChanged();
                    }
                } 
            }
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
