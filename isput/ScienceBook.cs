using System;
namespace isput
{
    public class ScienceBook: Book
    {
        private String _description { get; set; }
        public ScienceBook():base()
        {
            _description = "Default description";
        }
    }
}
