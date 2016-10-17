using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class NewExpression : Expression
    {
        public Expression Callee;
        public IEnumerable<Expression> Arguments;
    }
}