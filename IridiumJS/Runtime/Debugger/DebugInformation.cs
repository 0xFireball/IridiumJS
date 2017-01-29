using System;
using System.Collections.Generic;
using IridiumJS.Native;
using IridiumJS.Parser.Ast;
using IridiumJS.Runtime.Environments;

namespace IridiumJS.Runtime.Debugger
{
    public class DebugInformation : EventArgs
    {
        public Stack<String> CallStack { get; set; }
        public Statement CurrentStatement { get; set; }
        public Dictionary<string, JsValue> Locals { get; set; }
        public Dictionary<string, JsValue> Globals { get; set; }
    }
}
