using System.Runtime.CompilerServices;

namespace Marqdouj.CLRCommon
{
    public class StateContainer
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
        }

        public event Action<string>? OnChange;

        protected void NotifyStateChanged(string e) => OnChange?.Invoke(e);
    }
}
