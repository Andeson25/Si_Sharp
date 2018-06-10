using System;
using System.Collections.Generic;

namespace BookLibrary
{
    public class ScienceBook : Book
    {
        private String _description;
        public String Description
        {
            get { return _description; }
            set { this._description = value; }
        }
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
            Console.WriteLine("_______________\nid: {0}\nName: {1}\nAuthor: {2}\nIs bought: {3}\nPrice: {4}\nDescription: {5}\n_______________"
                              , _id, _name, _author, _isBought, _price, _description);
        }

        public override void buy()
        {
            if (this.bookHasBeenBought != null)
            {
                if(this._isBought==false)
                {
                    this._isBought = true;
                    this.bookHasBeenBought($"Science Book with id {this._id} has been bought bought for {this._price}");
                    this._price = 0;
                }
                else
                {
                    this.bookHasBeenBought("You can`t buy science book that has already been sold");
                }
            }
        }
        public override string ToString()
        {
            return $"Id={this.Id}\nName={this.Name}\nAuthor={this.Author}\nPrice={this.Price}\nIs Bought={this.isBought}\nDecription={this.Description}";
        }

        public override void sell(Double price)
        {
            if (this.bookHasBeenBought != null)
            {
                if (this._isBought == true)
                {
                    this._price = price;
                    this._isBought = false;
                    this.bookHasBeenBought($"Science Book with id {this._id} has been sold for {this._price}");
                }
                else
                {
                    this.bookHasBeenBought("You can`t sell science book that has not been bought");
                }
            }
        }
        public override string[] toArray()
        {
            string[] arr = {this.Id.ToString() , this.Name, this.Author, this.Price.ToString(), this.isBought.ToString(), this.Description };
            return arr;
        }
    }
}
