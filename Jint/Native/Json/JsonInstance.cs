using IridiumJS.Native.Object;
using IridiumJS.Runtime;
using IridiumJS.Runtime.Interop;

namespace IridiumJS.Native.Json
{
    public sealed class JsonInstance : ObjectInstance
    {
        private readonly JSEngine _engine;

        private JsonInstance(JSEngine engine)
            : base(engine)
        {
            _engine = engine;
            Extensible = true;
        }

        public override string Class
        {
            get
            {
                return "JSON";
            }
        }

        public static JsonInstance CreateJsonObject(JSEngine engine)
        {
            var json = new JsonInstance(engine);
            json.Prototype = engine.Object.PrototypeObject;
            return json;
        }

        public void Configure()
        {
            FastAddProperty("parse", new ClrFunctionInstance(Engine, Parse, 2), true, false, true);
            FastAddProperty("stringify", new ClrFunctionInstance(Engine, Stringify, 3), true, false, true);
        }

        public JsValue Parse(JsValue thisObject, JsValue[] arguments)
        {
            var parser = new JsonParser(_engine);

            return parser.Parse(TypeConverter.ToString(arguments[0]));
        }

        public JsValue Stringify(JsValue thisObject, JsValue[] arguments)
        {
            JsValue 
                value = Undefined.Instance, 
                replacer = Undefined.Instance,
                space = Undefined.Instance;

            if (arguments.Length > 2)
            {
                space = arguments[2];
            }

            if (arguments.Length > 1)
            {
                replacer = arguments[1];
            }

            if (arguments.Length > 0)
            {
                value = arguments[0];
            }

            var serializer = new JsonSerializer(_engine);
            if (value == Undefined.Instance && replacer == Undefined.Instance) {
                return Undefined.Instance;
            }
            else {
                return serializer.Serialize(value, replacer, space);
            }
        }
    }
}
