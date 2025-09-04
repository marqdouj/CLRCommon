using Marqdouj.CLRCommon;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        [TestMethod]
        public void StateContainer_Manual_StateChanged()
        {
            //arrange
            var state = new TestState();

            //act 
            state.ValueStateChanged = true;

            //assert
            Assert.AreEqual(nameof(TestState.ValueStateChanged), state.LastChanged);
        }

        [TestMethod]
        public void StateContainer_Manual_PropertyChanged()
        {
            //arrange
            var state = new TestState();

            //act 
            state.ValuePropertyChanged = true;

            //assert
            Assert.AreEqual(nameof(TestState.ValuePropertyChanged), state.LastChanged);
        }

        [TestMethod]
        public void StateContainer_ValueWillChange_True()
        {
            //arrange
            var state = new TestState();
            const string oldValue = "oldValue";
            const string newValue = "newValue";

            //act 
            var willChange = TestState.ValueWillChange<string>(oldValue, newValue);

            //assert
            Assert.IsTrue(willChange);
        }

        [TestMethod]
        public void StateContainer_ValueWillChange_False()
        {
            //arrange
            var state = new TestState();
            const string oldValue = "sameValue";
            const string newValue = "sameValue";

            //act 
            var willChange = TestState.ValueWillChange<string>(oldValue, newValue);

            //assert
            Assert.IsFalse(willChange);
        }

        [TestMethod]
        public void StateContainer_ValueWillChange_False_OldNull_NewNull()
        {
            //arrange
            var state = new TestState();
            const string? oldValue = null;
            const string? newValue = null;

            //act 
            var willChange = TestState.ValueWillChange<string?>(oldValue, newValue);

            //assert
            Assert.IsFalse(willChange);
        }

        private class TestState : StateContainer, IDisposable
        {
            public TestState()
            {
                StateChanged += TestState_StateChanged;
                PropertyChanged += TestState_PropertyChanged;
            }

            public string? LastChanged { get; private set; }

            private void TestState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
            {
                PropertyChangedFired++;
                LastChanged += e.PropertyName;
            }

            private void TestState_StateChanged(string propertyName)
            {
                StateChangedFired++;
                LastChanged = propertyName;
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

            #region ValuePropertyChanged
            private bool _valuePropertyChanged;
            public bool ValuePropertyChanged
            {
                get => _valuePropertyChanged;
                set
                {
                    if (_valuePropertyChanged != value)
                    {
                        _valuePropertyChanged = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            #endregion

            #region ValueStateChanged
            private bool _valueStateChanged;
            public bool ValueStateChanged
            {
                get => _valueStateChanged;
                set
                {
                    if (_valueStateChanged != value)
                    {
                        _valueStateChanged = value;
                        NotifyStateChanged();
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
