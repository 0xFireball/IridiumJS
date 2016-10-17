using IridiumJS.Native;
using IridiumJS.Runtime.Interop;
using System;

namespace IridiumJS.Tests.Runtime.Converters
{
    public class EnumsToStringConverter : IObjectConverter
    {
        public bool TryConvert(object value, out JsValue result)
        {
            if (value is Enum)
            {
                result = value.ToString();
                return true;
            }

            result = JsValue.Null;
            return false;
        }
    }
}
