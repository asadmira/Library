using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class Data
    {
        public List<User> users = new List<User>();
        public List<Book> books = new List<Book>();
    }

    public static class ProgramData
    {
        public static Data data = new Data();
    }
}
