using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Сущность пользователя.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Индивидуальный номер пользователя.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Список книг, которые на руках у пользователя.
        /// </summary>
        public List<Book> Books { get; set; }
       

    }
}
