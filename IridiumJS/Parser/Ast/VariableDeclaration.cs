using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class VariableDeclaration : Statement
    {
        public IEnumerable<VariableDeclarator> Declarations;
        public string Kind;
    }
}