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
        protected virtual void SetValue<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!ValueWillChange(oldValue, newValue))
                return;

            oldValue = newValue;
            NotifyChanged(propertyName);
        }

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
        /// <returns>true if the value was changed</returns>
        protected virtual bool SetValueB<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!ValueWillChange(oldValue, newValue))
                return false;

            oldValue = newValue;
            NotifyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Determines if the value will be changed.
        /// Used by the SetValue method as a pre-condition to changing the value.
        /// Can be used in custom scenarios where there is a need to 
        /// determine if the value would have changed if SetValue was used.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool ValueWillChange<T>(T oldValue, T newValue) 
        {
            if (oldValue is null && newValue is null) return false;
            if (oldValue?.Equals(newValue) ?? false) return false;
            return true; 
        }

        /// <summary>
        /// Invokes NotifyStateChanged/NotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName">
        /// Compiler automatically resolves the property name based on the name of the calling method.
        /// override this value by explicitly setting the value when calling this method.
        /// </param>
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

        /// <summary>
        /// Invokes StateChanged
        /// </summary>
        /// <param name="propertyName">
        /// Compiler automatically resolves the property name based on the name of the calling method.
        /// override this value by explicitly setting the value when calling this method.
        /// </param>
        protected virtual void NotifyStateChanged([CallerMemberName] string propertyName = "")
        {
            if (suppressNotifications) return;
            StateChanged?.Invoke(propertyName);
        }

        /// <summary>
        /// Invoked when a property of the container changes. Used for data binding.
        /// href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0"
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invokes PropertyChanged
        /// </summary>
        /// <param name="propertyName">
        /// Compiler automatically resolves the property name based on the name of the calling method.
        /// override this value by explicitly setting the value when calling this method.
        /// </param>
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (suppressNotifications) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
