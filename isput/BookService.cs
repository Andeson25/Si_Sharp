using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace isput
{
    public class BookService
    {
        public static Book FindOne(Int32 id)
        {
            string json = File.ReadAllText("../../books.json");
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            List<Book> books = new List<Book>();
            foreach (JObject one in objects)
            {
                if (one.ContainsKey("Description"))
                    books.Add(JsonConvert.DeserializeObject<ScienceBook>(one.ToString()));
                else
                    books.Add(JsonConvert.DeserializeObject<Book>(one.ToString()));
            }
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
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            List<Book> books = new List<Book>();
            foreach (JObject one in objects)
            {
                if (one.ContainsKey("Description"))
                    books.Add(JsonConvert.DeserializeObject<ScienceBook>(one.ToString()));
                else
                    books.Add(JsonConvert.DeserializeObject<Book>(one.ToString()));
            }
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
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            List<Book> books = new List<Book>();
            foreach (JObject one in objects)
            {
                if (one.ContainsKey("Description"))
                    books.Add(JsonConvert.DeserializeObject<ScienceBook>(one.ToString()));
                else
                    books.Add(JsonConvert.DeserializeObject<Book>(one.ToString()));
            }
            return books;
        }
    }
}
