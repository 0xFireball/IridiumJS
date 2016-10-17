using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class ArrayExpression : Expression
    {
        public IEnumerable<Expression> Elements;
    }
}