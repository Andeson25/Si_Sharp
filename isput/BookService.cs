using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace isput
{
    public class BookService
    {
        public Book FindOne(Int32 id)
        {
            string json = File.ReadAllText("../../books.json");
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            foreach (Book one in books)
            {
                if (one.Id == id)
                    return one;
            }
            return new Book();
        }
        public static Book FindMostExpensive()
        {
            string json = File.ReadAllText("../../books.json");
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            Book max = new Book();
            BookCompare compare = new BookCompare();
            foreach (Book one in books)
            {
                if (compare.Compare(one, max) >= 0)
                    max = one;
            }
            return max;
        }
        public static List<Book> FindAll()
        {
            string json = File.ReadAllText("../../books.json");
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            return books;
        }
    }
}
