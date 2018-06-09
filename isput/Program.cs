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
            var book = new Book("name", "author", true, 100.5);
            book.print();
        }
    }
}