using IridiumJS.Runtime;

namespace IridiumJS.Native
{
    public interface IPrimitiveInstance
    {
        Types Type { get; } 
        JsValue PrimitiveValue { get; }
    }
}
