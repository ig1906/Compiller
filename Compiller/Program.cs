using Compiller.CompillerStages;
using Compiller.Services;
using NLog;
using System;

namespace Compiller
{
    class Program
    {
        /// <summary>
        /// Статичное поле логгера
        /// </summary>
        public static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Запуск лексера
            var DHandler = new DataHandler();
            var lexer = new Lexer();
            //Временное решение, в дальнейшем будет пересмотрен вызов методов
            var D = lexer.GetTokensTable(lexer.GetTokens(DHandler.OpenCode()));
            lexer.GetIdentiefersTable(D);
            Console.ReadKey();
        }
    }
}
