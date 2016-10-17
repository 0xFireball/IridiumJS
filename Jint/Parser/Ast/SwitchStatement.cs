using System.Collections.Generic;

namespace IridiumJS.Parser.Ast
{
    public class SwitchStatement : Statement
    {
        public Expression Discriminant;
        public IEnumerable<SwitchCase> Cases;
    }
}