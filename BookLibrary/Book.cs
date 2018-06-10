using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace BookLibrary
{
    public delegate void bookEvent(String message);
    public class Book : IComparable
    {
        private static int _globalID = 0;
        protected Int32 _id;
        protected String _name;
        protected String _author;
        protected Double _price;
        protected Boolean _isBought;



        protected bookEvent bookHasBeenBought;
        protected bookEvent bookHasBeenSold;


        public event bookEvent BookHasBeenBought
        {
            add { bookHasBeenBought += value; }
            remove { bookHasBeenBought -= value; }
        }
        public event bookEvent BookHasBeenSold
        {
            add { bookHasBeenSold += value; }
            remove { bookHasBeenSold -= value; }
        }
        public Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public String Name
        {
            get { return this._name; }

            set { this._name = value; }
        }
        public String Author
        {
            get { return this._author; }
            set { this._author = value; }
        }
        public Double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }
        public Boolean isBought
        {
            get { return this._isBought; }
            set { this._isBought = value; }
        }
        public Book()
        {
            if (_globalID == 0)
                _id = 1;
            _globalID += 1;
            _id = _globalID;
            _name = "DefaultName";
            _author = "DefaultAuthor";
            _price = 0;
            isBought = true;
        }
        public Book(string name, string author, bool isBought, double price)
        {
            if (_globalID == 0)
                _id = 1;
            _globalID += 1;
            _id += 1;
            this._name = name;
            this._author = author;
            this._price = price;
            this._isBought = isBought;
        }

        public virtual void buy()
        {
            if (bookHasBeenBought != null)
            {
                if (this._isBought == false)
                {
                    this._isBought = true;
                    this.bookHasBeenBought($"Book with id {this._id} has been bought bought for {this._price}");
                    this._price = 0;
                }
                else
                {
                    this.bookHasBeenBought("You can`t buy  book that has already been sold");
                }
            }
        }
        public virtual void sell(Double price)
        {
            if (bookHasBeenSold != null)
            {
                if (this._isBought == true)
                {
                    this._price = price;
                    this._isBought = false;
                    this.bookHasBeenBought($"Book with id {this._id} has been sold for {this._price}");
                }
                else
                {

                    this.bookHasBeenBought("You can`t sell  book that has not been bought");
                }
            }

        }
        public static bool operator <(Book left, Book right)
        {
            return left.Price < right.Price;
        }

        public static bool operator >(Book left, Book right)
        {
            return left.Price > right.Price;
        }


        public virtual void print()
        {
            Console.WriteLine("_______________\nid: {0}\nName: {1}\nAuthor: {2}\nIs bought: {3}\nPrice: {4}\n_______________\n"
                              , _id, _name, _author, _isBought, _price);
        }

        public Book(Book obj)
        {
            this._id = obj.Id;
            this._author = obj.Author;
            this._name = obj.Name;
            this._price = obj.Price;
            this._isBought = this._price == 0.0 ? true : false;
        }

        public override string ToString()
        {
            return $"Id={this.Id}\nName={this.Name}\nAuthor={this.Author}\nPrice={this.Price}\nIs Bought={this.isBought}";
        }
        public virtual string[] toArray()
        {
            string[] arr = {this.Id.ToString(), this.Name, this.Author, this.Price.ToString(), this.isBought.ToString() };
            return arr;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Book book = obj as Book;
            if (this.Price.CompareTo(book.Price) > 0)
            {
                return 1;
            }
            else
               if (this.Price.CompareTo(book.Price) < 0)
            {
                return -1;
            }
            return 0;
        }
    }
}
