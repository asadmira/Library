using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    static public class UserController
    {

        static public User CreateUser(string firstName, string lastName, string birthDate, string phoneNumber, string email)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.BirthDate = birthDate;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            //user.Id = ;
            return user;
        }

        static public List<User> UsersWithBooks(List<User> users)
        {
            return users.Where(user => user.Books != null && user.Books.Count > 0).ToList<User>();
        }

        static public List<User> UserWithExpiredBooks(List<User> users)
        {
            return users.Where(user => user.Books != null && user.Books.Count > 0 && user.Books.Exists(BookController.IsExpiredBook)).ToList<User>();
        }
    }
}
