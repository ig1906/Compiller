using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiller.Models
{
    class LexemTypes
    {
        /// <summary>
        /// Служебные(зарезервированные) слова
        /// </summary>
        public readonly List<string> Keyword = new List<string>() { "program", "var", "integer", "begin", "end", "for", "to", "do", "if", "then", "else", "while", "const" };
        /// <summary>
        /// Арифметические операторы
        /// </summary>
        public readonly List<string> ArithmeticSign = new List<string>() { "+", "-", "*", "/", "=", "<", ">", "<>" };
        /// <summary>
        /// Логические операторы
        /// </summary>
        public readonly List<string> LogicalSign = new List<string>() { "or", "and", "not", "xor", "true", "false" };
        /// <summary>
        /// Разделители
        /// </summary>
        public readonly List<string> Separator = new List<string>() { ";", ",", ".", "(", ")", ":" };
        /// <summary>
        /// Оператор присваивания
        /// </summary>
        public readonly string AssignmentOperator = ":=";
    }
}
