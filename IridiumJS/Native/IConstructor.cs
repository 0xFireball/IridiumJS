using IridiumJS.Native.Object;

namespace IridiumJS.Native
{
    public interface IConstructor
    {
        JsValue Call(JsValue thisObject, JsValue[] arguments);
        ObjectInstance Construct(JsValue[] arguments);
    }
}
