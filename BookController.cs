using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    static public class BookController
    {

        static public Book CreateBook(string name, string author, DateTime takeDate, DateTime returnDate)
        {
            Book book = new Book();
            book.Name = name;
            book.Author = author;
            book.TakeDate = takeDate;
            book.ReturnDate = returnDate;
                     
            return book;
        }

        static public List<Book> ExpiredBooks(List<Book> books)
        {
            return books.Where(book => IsExpiredBook(book)).ToList<Book>();
        }

        static public bool IsExpiredBook(Book book)
        {
            return book.ReturnDate.CompareTo(DateTime.Today) > 0;
        }
    }
}
