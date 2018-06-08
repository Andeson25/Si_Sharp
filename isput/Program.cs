using System;
using System.IO;

namespace isput
{
    class MainClass
    {
        public static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
        public static void Main(string[] args)
        {
            Book book0 = new Book("BookName","BookAuthor",false,500);
            book0.bookHasBeenBought += Show_Message;
            book0.bookHasBeenSold += Show_Message;
            book0.buy();
            book0.print();
            book0.sell(1000);
            book0.print();
            book0.bookHasBeenBought -= Show_Message;
            book0.bookHasBeenSold -= Show_Message;
        }

    }
}
