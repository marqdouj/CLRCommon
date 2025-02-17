using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Marqdouj.CLRCommon
{
    public class StateContainer : INotifyPropertyChanged
    {
        /// <summary>
        /// If the value is different, then sets the value and invokes OnChange.
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
            NotifyStateChanged(propertyName);
            NotifyPropertyChanged(propertyName);
        }

        public event Action<string>? StateChanged;

        protected void NotifyStateChanged(string e) => StateChanged?.Invoke(e);


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
