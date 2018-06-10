using System;

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
            BookService.FindAll();
        }
    }
}