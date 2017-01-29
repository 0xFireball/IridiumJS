using System.Dynamic;

namespace IridiumJS
{
    public class DynamicVariableSetter : DynamicObject, IDynamicMetaObjectProvider
    {
        private JSEngine engine;

        public DynamicVariableSetter(JSEngine engine)
        {
            this.engine = engine;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            result = engine.GetValue(binder.Name);
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            engine.SetValue(binder.Name, value);
            return true;
        }
    }
}