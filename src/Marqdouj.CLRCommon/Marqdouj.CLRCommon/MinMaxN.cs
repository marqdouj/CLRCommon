using System.Numerics;

namespace Marqdouj.CLRCommon
{
    public class MinMaxN<T> : StateContainer where T : INumber<T>
    {
        private T _value;

        public MinMaxN(T min, T max, T value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);

            Min = min;
            Max = max;
            _value = value;
        }

        public T Min { get; }

        public T Max { get; }

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
