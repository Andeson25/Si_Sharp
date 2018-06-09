using System;
using Newtonsoft.Json.Serialization;

namespace isput
{
    public delegate void bookEvent(String message);
    public class Book
    {
        private static int _globalID = 0;
        private Int32 _id;
        private String _name;
        private String _author;
        private Double _price;
        private Boolean _isBought;



        public event bookEvent bookHasBeenBought;
        public event bookEvent bookHasBeenSold;

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
        public Book()
        {
            if (_globalID == 0)
                _id = 1;
            _globalID += 1;
            _id = _globalID;
            _name = "DefaultName";
            _author = "DefaultAuthor";
            _price = 0;
            _isBought = false;
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

        public void buy()
        {
            if (bookHasBeenBought != null)
            {
                this._isBought = true;
                this.bookHasBeenBought($"Book has been bought bought for {this._price}");
                this._price = 0;
            }
        }
        public void sell(Double price)
        {
            if (bookHasBeenSold != null)
            {
                this._price = price;
                this._isBought = false;
                this.bookHasBeenBought($"Book has been sold for {this._price}");
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




        public override string ToString()
        {
            return base.ToString();
        }

        public void print()
        {
            Console.WriteLine("_______________\nid: {0}\nName: {1}\nAuthor: {2}\nIs bought: {3}\nPrice: {4}\n_______________\n", _id, _name, _author, _isBought, _price);
        }

        public Book(Book obj)
        {
            this._id = obj.Id;
            this._author = obj.Author;
            this._name = obj.Name;
            this._price = obj.Price;
        }
    }
}
