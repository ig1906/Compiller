using Compiller.Interfaces;
using Compiller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiller.CompillerStages
{
    /// <summary>
    /// Класс Lexer реализует интерфейс ILexer, это сделано для придания коду пафосности и SOLIDности
    /// </summary>
    class Lexer : ILexer
    {
        /// <summary>
        /// Метод получает на вход таблицу лексем, обрабатывает ее и возвращает таблицу идентификаторов
        /// </summary>
        /// <param name="tokensTable"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetIdentiefersTable(List<TokensTable> tokensTable)
        {
            var IdentiefersTable = new Dictionary<string, string>();
            foreach (var item in tokensTable)
            {
                if (item.Type == "Идентификатор")
                {
                    try
                    {
                        IdentiefersTable.Add(HashFunction(item.Token), item.Token);
                        Program.logger.Debug("Найден идентификатор " + item.Token + " ему присвоен хеш " + HashFunction(item.Token));
                    }
                    catch (Exception e)
                    {
                        Program.logger.Error("Поймано исключение, данный идентификатор уже обнаружен, пропускаю его и продолжаю искать... " + e);
                        continue;
                    }
                }
            }
            Program.logger.Debug("Таблица идентификаторов получена. Вывожу в консоль...");
            Console.WriteLine("Таблица идентификаторов:");
            Console.WriteLine("Хеш" + "   " + "Идентификатор");
            foreach (var item in IdentiefersTable)
                Console.WriteLine(item.Key + " " + item.Value);
            return IdentiefersTable;
        }
        /// <summary>
        /// Метод получает на вход строку с кодом, обрабатывает ее с помощью регулярных выражений и возвращает массив токенов следующих по порядку
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<string> GetTokens(string code)
        {
            var tokens = new List<string>();
            string pattern = @"\d+|\b[a-zA-Z]+\b|[+-]+|[-.?!)(,:;=<>]+";
            Regex rg = new Regex(pattern);
            MatchCollection matchedTokens = rg.Matches(code);
            Program.logger.Debug("Последовательность лексем получена, вывожу в консоль и возвращаю ретурном в виде массива.");
            foreach (var token in matchedTokens)
                tokens.Add(token.ToString());
            return tokens;
        }
        /// <summary>
        /// Метод получает на вход массив токенов, возвращает таблицу лексем
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public List<TokensTable> GetTokensTable(List<string> tokens)
        {
            var LexemTypes = new LexemTypes();
            try
            {
                var list = new List<TokensTable>();
                int it = 0;
                foreach (var token in tokens)
                {
                    it++;
                    string type;
                    if (LexemTypes.Keyword.Contains(token))
                        type = "Ключевое слово";
                    else if (LexemTypes.ArithmeticSign.Contains(token))
                        type = "Арифметическая операция";
                    else if (LexemTypes.LogicalSign.Contains(token))
                        type = "Логическая операция";
                    else if (LexemTypes.Separator.Contains(token))
                        type = "Разделитель";
                    else if (token == ":=")
                        type = "Оператор присваивания";
                    else
                        type = "Идентификатор";
                    list.Add(new TokensTable() { Id = it, Token = token, Type = type });
                }
                Program.logger.Debug("Получена таблица лексем. Вывожу в консоль. Модель данных, описывающих таблицу верну после выполнения метода.");
                Console.WriteLine("Таблица лексем:");
                Console.WriteLine("Идентификатор" + "   " + "Лексема" + "   " + "Тип лексемы");
                foreach (var i in list)
                    Console.WriteLine(i.Id + "               " + i.Token + "          " + i.Type);
                return list;
            }
            catch (Exception e)
            {
                Program.logger.Debug("Не удалось построить таблицу лексем. Утка на реактивной тяге словила эксепшен: " + e);
                return null;
            }
        }
        /// <summary>
        /// Метод, реализующий хеш-функцию по алгоритму SHA256, на вход подается идентификатор, на выходе получаем хеш
        /// </summary>
        /// <param name="identiefer"></param>
        /// <returns></returns>
        private string HashFunction(string identiefer)
        {
            byte[] data = Encoding.Default.GetBytes(identiefer);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
