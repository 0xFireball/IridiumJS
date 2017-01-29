using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class ObjectExpression : Expression
    {
        public IEnumerable<Property> Properties;
    }
}