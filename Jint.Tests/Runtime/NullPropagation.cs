using IridiumJS.Native;
using IridiumJS.Native.Object;
using IridiumJS.Parser;
using IridiumJS.Runtime;
using IridiumJS.Runtime.Interop;
using IridiumJS.Runtime.References;
using Xunit;

namespace IridiumJS.Tests.Runtime
{
    public class NullPropagation
    {
        public class NullPropagationReferenceResolver : IReferenceResolver
        {
            public bool TryUnresolvableReference(JSEngine JSEngine, Reference reference, out JsValue value)
            {
                value = reference.GetBase();
                return true;
            }

            public bool TryPropertyReference(JSEngine JSEngine, Reference reference, ref JsValue value)
            {
                return value.IsNull() || value.IsUndefined();
            }

            public bool TryGetCallable(JSEngine JSEngine, object reference, out JsValue value)
            {
                value = new JsValue(
                    new ClrFunctionInstance(JSEngine, (thisObj, values) => thisObj)
                );
                return true;
            }
            
            public bool CheckCoercible(JsValue value)
            {
                return true;
            }
        }

        [Fact]
        public void NullPropagationTest()
        {
            var JSEngine = new JSEngine(cfg => cfg.SetReferencesResolver(new NullPropagationReferenceResolver()));

            const string Script = @"
var input = { 
	Address : null 
};

var address = input.Address;
var city = input.Address.City;
var length = input.Address.City.length;

var output = {
	Count1 : input.Address.City.length,
	Count2 : this.XYZ.length
};
";

            JSEngine.Execute(Script);

            var address = JSEngine.GetValue("address");
            var city = JSEngine.GetValue("city");
            var length = JSEngine.GetValue("length");
            var output = JSEngine.GetValue("output").AsObject();

            Assert.Equal(Null.Instance, address);
            Assert.Equal(Null.Instance, city);
            Assert.Equal(Null.Instance, length);

            Assert.Equal(Null.Instance, output.Get("Count1"));
            Assert.Equal(Undefined.Instance, output.Get("Count2"));
        }

        [Fact]
        public void NullPropagationFromArg()
        {
            var JSEngine = new JSEngine(cfg => cfg.SetReferencesResolver(new NullPropagationReferenceResolver()));


            const string Script = @"
function test(arg) {
    return arg.Name;
}

function test2(arg) {
    return arg.Name.toUpperCase();
}
";
            JSEngine.Execute(Script);
            var result = JSEngine.Invoke("test", Null.Instance);

            Assert.Equal(Null.Instance, result);

            result = JSEngine.Invoke("test2", Null.Instance);

            Assert.Equal(Null.Instance, result);
        }

        [Fact]
        public void NullPropagationShouldNotAffectOperators()
        {
            var JSEngine = new JSEngine(cfg => cfg.SetReferencesResolver(new NullPropagationReferenceResolver()));

            var jsObject = JSEngine.Object.Construct(Arguments.Empty);
            jsObject.Put("NullField", JsValue.Null, true);

            var script = @"
this.is_nullfield_not_null = this.NullField !== null;
this.is_notnullfield_not_null = this.NotNullField !== null;
this.has_emptyfield_not_null = this.EmptyField !== null;
";

            var wrapperScript = string.Format(@"function ExecutePatchScript(docInner){{ (function(doc){{ {0} }}).apply(docInner); }};", script);

            JSEngine.Execute(wrapperScript, new ParserOptions
            {
                Source = "main.js"
            });

            JSEngine.Invoke("ExecutePatchScript", jsObject);

            Assert.False(jsObject.Get("is_nullfield_not_null").AsBoolean());
            Assert.True(jsObject.Get("is_notnullfield_not_null").AsBoolean());
            Assert.True(jsObject.Get("has_emptyfield_not_null").AsBoolean());
        }
    }
}