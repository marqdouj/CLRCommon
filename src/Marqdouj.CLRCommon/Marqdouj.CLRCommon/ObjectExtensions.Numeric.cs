namespace Marqdouj.CLRCommon
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks if the underlying type code is a number.
        /// TypeCodes: UInt16,UInt32,UInt64,Int16,Int32,Int64,Decimal,Double,Single, and Byte/SByte if includeByte = true.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="includeByte">Flag to include Byte/SByte as a number. Default false.</param>
        /// <returns></returns>
        public static bool IsNumber(this object? obj, bool includeByte = false)
        {
            if (obj == null) return false;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                    return includeByte;
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
