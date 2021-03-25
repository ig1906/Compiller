using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiller.Models
{
    /// <summary>
    /// Модель данных таблицы лексем
    /// </summary>
    class TokensTable
    {
        /// <summary>
        /// Порядковый номер токена в коде
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Лексема
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Тип лексемы
        /// </summary>
        public string Type { get; set; }
    }
}
