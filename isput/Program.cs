using System;
using System.Collections.Generic;

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
            List<Book> books = BookService.FindAll();
            foreach (Book one in books)
            {
                one.bookHasBeenBought += BookEvent;
                one.bookHasBeenSold += BookEvent;

                if (one is ScienceBook)
                {
                    Console.WriteLine($"Found ScinceBook with id = {one.Id}");
                }
                if (one.Id == 3)
                {
                    one.buy();
                }
                if(one.Id==6)
                {
                    one.sell(90000);
                }
                one.bookHasBeenBought -= BookEvent;
                one.bookHasBeenSold -= BookEvent;
            }
            Console.WriteLine("NEW COLLECTION \n");
            foreach( Book one in books)
            {
              
                one.print();
            }

        }
    }
}