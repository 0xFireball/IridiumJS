using System;
using System.Collections.Generic;
using System.Linq;

using IridiumJS.Native;
using IridiumJS.Parser.Ast;

namespace IridiumJS.Runtime
{
    using IridiumJS.Runtime.CallStack;

    public class RecursionDepthOverflowException : Exception
    {
        public string CallChain { get; private set; }

        public string CallExpressionReference { get; private set; }

        public RecursionDepthOverflowException(JintCallStack currentStack, string currentExpressionReference)
            : base("The recursion is forbidden by script host.")
        {
            CallExpressionReference = currentExpressionReference;

            CallChain = currentStack.ToString();
        }
    }
    
}
