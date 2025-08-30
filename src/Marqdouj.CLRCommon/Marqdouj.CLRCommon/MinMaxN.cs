using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

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
        [JsonConstructor]
        public MinMaxN(T min, T max, T value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);

            Min = min;
            Max = max;
            _value = CoerceValue(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinMaxN{T}"/> class.
        /// Value is set to the minimum value.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public MinMaxN(T min, T max)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);

            Min = min;
            Max = max;
            _value = min;
        }

        /// <summary>
        /// The minimum value in the range.
        /// </summary>
        public T Min { get; }

        /// <summary>
        /// The maximum value in the range.
        /// </summary>
        public T Max { get; }

        public T Width => Max - Min;

        public T Center => Min + (Width / T.CreateChecked(2));

        /// <summary>
        /// The current value within the range.
        /// Value is coerced to the minimum or maximum value if it is outside the range.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                value = CoerceValue(value);

                SetValue(ref _value, value);
            }
        }

        private T CoerceValue(T value)
        {
            if (value < Min)
                value = Min;
            if (value > Max)
                value = Max;
            return value;
        }

        /// <summary>
        /// normally used for html text input components that support numbers, i.e. FluentTextField
        /// </summary>
        [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessage = "Only numeric values are allowed.")]
        public virtual string? StringValue 
        { 
            get => Value?.ToString();
            set 
            {
                if (T.TryParse(value, null, out var result))
                    Value = result;

                return;
            }
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "";
        }
    }
}
