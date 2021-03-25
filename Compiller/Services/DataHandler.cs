using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiller.Services
{
    class DataHandler
    {
        /// <summary>
        /// Метод открывает файл и получает содержимое
        /// </summary>
        /// <returns></returns>
        public string OpenCode()
        {
            Console.WriteLine("Введите путь к файлу с исходным кодом: ");
            string code = string.Empty;
            string path = Console.ReadLine();
            try
            {
                code = File.ReadAllText(path);
                Program.logger.Debug("Утка на реактивной тяге прочитала файл " + path + " И получила содержимое из " + code.Count() + " символов.");
                return code;
            }
            catch (Exception e)
            {
                Program.logger.Error("Утка на реактивной не смогла прочитать файл " + path + ", т.к. словила эксзепшен: " + e);
                return null;
            }
        }
    }
}
