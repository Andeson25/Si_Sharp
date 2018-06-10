using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookLibrary
{
    public class BookService
    {
        public static Book FindOne(Int32 id)
        {
            string json = File.ReadAllText("../../books.json");
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            foreach (JObject one in objects)
            {
                if (one.ContainsKey("Description"))
                    if ((Int32)one.GetValue("Id") == id)
                        return JsonConvert.DeserializeObject<ScienceBook>(one.ToString());
                if ((Int32)one.GetValue("Id") == id)
                    return JsonConvert.DeserializeObject<Book>(one.ToString());
            }
            return new Book();
        }
        public static Book FindMostExpensive()
        {
            string json = File.ReadAllText("../../books.json");
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            Book max = new Book();
            foreach (JObject one in objects)
            {
                if (one.ContainsKey("Description") && JsonConvert.DeserializeObject<ScienceBook>(one.ToString()).CompareTo(max) >= 0)
                    max = JsonConvert.DeserializeObject<ScienceBook>(one.ToString());
                else
                    if (JsonConvert.DeserializeObject<Book>(one.ToString()).CompareTo(max) >= 0)
                    max = JsonConvert.DeserializeObject<Book>(one.ToString());
            }
            return max;
        }
        public static List<Book> FindAll(String filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(json);
            List<Book> books = new List<Book>();
            if (objects!=null)
            {
                foreach (JObject one in objects)
                {
                    if (one.ContainsKey("Description"))
                        books.Add(JsonConvert.DeserializeObject<ScienceBook>(one.ToString()));
                    else
                        books.Add(JsonConvert.DeserializeObject<Book>(one.ToString()));
                }
            }
            return books;
        }
        public static void Save(List<Book> list, String path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
        }
    }
}
