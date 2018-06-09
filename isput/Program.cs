using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


namespace isput
{
    class MainClass

    {
        public static Book FindOne(Int32 id)
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
        public static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("FOUND BOOK WITH ID = 6");
            FindOne(6).print();
        }

    }
}
