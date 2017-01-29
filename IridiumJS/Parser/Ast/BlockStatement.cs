using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class BlockStatement : Statement
    {
        public IEnumerable<Statement> Body;
    }
}