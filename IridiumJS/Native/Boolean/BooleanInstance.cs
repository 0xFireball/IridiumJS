﻿using IridiumJS.Native.Object;
using IridiumJS.Runtime;

namespace IridiumJS.Native.Boolean
{
    public class BooleanInstance : ObjectInstance, IPrimitiveInstance
    {
        public BooleanInstance(JSEngine engine)
            : base(engine)
        {
        }

        public override string Class
        {
            get
            {
                return "Boolean";
            }
        }

        Types IPrimitiveInstance.Type
        {
            get { return Types.Boolean; }
        }

        JsValue IPrimitiveInstance.PrimitiveValue
        {
            get { return PrimitiveValue; }
        }

        public JsValue PrimitiveValue { get; set; }
    }
}
