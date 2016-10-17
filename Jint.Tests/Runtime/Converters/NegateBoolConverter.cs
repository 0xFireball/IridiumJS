using IridiumJS.Native;
using IridiumJS.Runtime.Interop;

namespace IridiumJS.Tests.Runtime.Converters
{
    public class NegateBoolConverter : IObjectConverter
    {
        public bool TryConvert(object value, out JsValue result)
        {
            if (value is bool)
            {
                result = !(bool) value;
                return true;
            }

            result = JsValue.Null;
            return false;
        }
    }
}
