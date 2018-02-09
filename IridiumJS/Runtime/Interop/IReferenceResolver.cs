using IridiumJS.Native;
using IridiumJS.Runtime.References;

namespace IridiumJS.Runtime.Interop
{
    public interface IReferenceResolver
    {
        bool TryUnresolvableReference(JSEngine engine, Reference reference, out JsValue value);
        bool TryPropertyReference(JSEngine engine, Reference reference, ref JsValue value);
        bool TryGetCallable(JSEngine engine, object callee, out JsValue value);
        bool CheckCoercible(JsValue value);
    }
}