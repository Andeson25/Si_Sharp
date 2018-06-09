using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace isput
{
    class MainClass

    {
        public static void BookEvent(String message)
        {
            Console.WriteLine(message);
        }
        public static void Main(string[] args)
        {
            string json = File.ReadAllText("../../books.json");
            JArray kek = new JArray(json);
            Console.WriteLine(kek.Count);
        }
    }
}