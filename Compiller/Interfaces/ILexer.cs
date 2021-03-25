using Compiller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiller.Interfaces
{
    /// <summary>
    /// Интерфейс лексера
    /// </summary>
    interface ILexer
    {
        public List<string> GetTokens(string code);
        public List<TokensTable> GetTokensTable(List<string> tokens);
        public Dictionary<string, string> GetIdentiefersTable(List<TokensTable> tokensTable);
    }
}
