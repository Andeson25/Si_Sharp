﻿using System;
namespace isput
{
    public class ScienceBook : Book
    {
        private String _description { get; set; }
        public ScienceBook() : base()
        {
            _description = "Default description";
        }
        public ScienceBook(String name, String author, Boolean isBought, Double price, String description) : base(name, author, isBought, price)
        {
            this._description = description;
        }
        public override void print()
        {
            Console.WriteLine("_______________\nid: {0}\nName: {1}\nAuthor: {2}\nIs bought: {3}\nPrice: {4}\n_______________\nDescription: {5}",_id, _name, _author, _isBought, _price,_description);
        }

    }
}
