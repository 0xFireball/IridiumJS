using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class SwitchCase : SyntaxNode
    {
        public Expression Test;
        public IEnumerable<Statement> Consequent;
    }
}