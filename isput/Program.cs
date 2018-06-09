using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace isput
{
    class MainClass

    {
        public static void BookEvent(String message)
        {
            Console.WriteLine(message);
        }
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
        public static List<Object> FindAll()
        {
            string json = File.ReadAllText("../../books.json");
            List<Object> books = JsonConvert.DeserializeObject<List<Object>>(json);
            return books;
        }
        public static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
        public static void Main(string[] args)
        {
            foreach(Object one in FindAll())
            {
                Console.WriteLine(one.ToString());
            }
            //foreach (Book one in FindAll())
            //{
            //    Console.WriteLine(one.GetType());
            //}
        }

    }
}
