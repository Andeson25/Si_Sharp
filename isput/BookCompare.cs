using System;
using System.Collections.Generic;

namespace isput
{
    public class BookCompare : IComparer<Book>
    {
        public int Compare(Book r1, Book r2)
        {
            if (r1.Price.CompareTo(r2.Price) > 0)
            {
                return 1;
            }
            else
                if (r1.Price.CompareTo(r2.Price) < 0)
            {
                return -1;
            }
            return 0;
        }

    }
}