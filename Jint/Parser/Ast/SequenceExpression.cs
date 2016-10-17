using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class SequenceExpression : Expression
    {
        public IList<Expression> Expressions;
    }
}