﻿using IridiumJS.Runtime.Environments;

namespace IridiumJS.Native.Function
{
    public sealed class FunctionShim : FunctionInstance
    {
        public FunctionShim(JSEngine engine, string[] parameters, LexicalEnvironment scope) : base(engine, parameters, scope, false)
        {
        }

        public override JsValue Call(JsValue thisObject, JsValue[] arguments)
        {
            return Undefined.Instance;
        }
    }
}
