using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    public class Book
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор книги.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Дата взятия книги пользователем.
        /// </summary>
        public DateTime TakeDate { get; set; }
        /// <summary>
        /// Дата ожидаемого возврата книги пользователем.
        /// </summary>
        public DateTime ReturnDate { get; set; }
        
    }
}
