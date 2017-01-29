using IridiumJS.Runtime;
using IridiumJS.Runtime.Descriptors;

namespace IridiumJS.Native.Function
{
    public sealed class ThrowTypeError : FunctionInstance
    {
        private readonly JSEngine _engine;

        public ThrowTypeError(JSEngine engine): base(engine, new string[0], engine.GlobalEnvironment, false)
        {
            _engine = engine;
            DefineOwnProperty("length", new PropertyDescriptor(0, false, false, false), false);
            Extensible = false;
        }

        public override JsValue Call(JsValue thisObject, JsValue[] arguments)
        {
            throw new JavaScriptException(_engine.TypeError);
        }
    }
}
