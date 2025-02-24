using System.Numerics;

namespace Marqdouj.CLRCommon
{
    /// <summary>
    /// Represents a number that is constrained between a minimum and maximum value.
    /// Derived from StateContainer to support Value state/property change notifications.
    /// </summary>
    /// <typeparam name="T"><see cref="INumber{TSelf}"/></typeparam>
    public class MinMaxN<T> : StateContainer where T : INumber<T>
    {
        private T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinMaxN{T}"/> class.
        /// </summary>
        /// <param name="min"><see cref="Min"/></param>
        /// <param name="max"><see cref="Max"/></param>
        /// <param name="value"><see cref="Value"/></param>
        public MinMaxN(T min, T max, T value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);

            Min = min;
            Max = max;
            _value = value;
        }

        /// <summary>
        /// The minimum value in the range.
        /// </summary>
        public T Min { get; }

        /// <summary>
        /// The maximum value in the range.
        /// </summary>
        public T Max { get; }

        /// <summary>
        /// The current value within the range.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                if (value < Min)
                    value = Min;
                if (value > Max)
                    value = Max;

                SetValue(ref _value, value);
            }
        }
    }
}
