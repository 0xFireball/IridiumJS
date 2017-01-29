using System.Collections.Generic;
using IridiumJS.Parser.Ast;

namespace IridiumJS.Parser
{
    public interface IFunctionDeclaration : IFunctionScope
    {
        Identifier Id { get; }
        IEnumerable<Identifier> Parameters { get; }
        Statement Body { get; }
        bool Strict { get; }
    }
}