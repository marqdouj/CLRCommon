using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace Marqdouj.CLRCommon
{
    public class StateContainer : INotifyPropertyChanged
    {
        /// <summary>
        /// If the value is different, then sets the value and invokes StateChanged/PropertyChanged.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName">
        /// Compiler automatically resolves the property name based on the name of the calling method.
        /// override this value by explicitly setting the value when calling this method.
        /// </param>
        protected void SetValue<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (oldValue is null && newValue is null) return;
            if (oldValue?.Equals(newValue) ?? false) return;

            oldValue = newValue;
            NotifyChanged(propertyName);
        }

        /// <summary>
        /// Invokes NotifyStateChanged/NotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotifyChanged([CallerMemberName] string propertyName = "")
        {
            NotifyStateChanged(propertyName);
            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Indicates whether notifications should be suppressed (default = false). 
        /// false - all notifications are sent; true - all notifications are suppressed.
        /// This is useful when you want to suppress notifications while updating many values.
        /// </summary>
        #region SuppressNotifications
        private bool suppressNotifications;
        public bool SuppressNotifications { get => suppressNotifications; set => SetValue(ref suppressNotifications, value); }
        #endregion

        /// <summary>
        /// Invoked when the state of the container changes (i.e. Blazor state management).
        /// href="https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-9.0&pivots=server#in-memory-state-container-service"
        /// </summary>
        public event Action<string>? StateChanged;

        protected virtual void NotifyStateChanged(string propertyName)
        {
            if (suppressNotifications) return;
            StateChanged?.Invoke(propertyName);
        }

        /// <summary>
        /// Invoked when a property of the container changes. Used for data binding.
        /// href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0"
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (suppressNotifications) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
