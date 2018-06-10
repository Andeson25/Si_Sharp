using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookLibrary;

namespace BookWindowsForm
{
    public partial class addForm : Form
    {
        Boolean isScinceBook = false;
        internal Book result;

        public addForm()
        {
            InitializeComponent();
            textBox4.Visible = false;
            label3.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isScinceBook = !isScinceBook;
            if (isScinceBook)
            {
                textBox4.Visible = true;
                label3.Visible = true;
            }
            else
            {
                textBox4.Text = "";
                label3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox3.Text != "")
            {
                if (textBox4.Text!="")
                {
                    ScienceBook scienceBook = new ScienceBook();
                    scienceBook.Name = textBox1.Text;
                    scienceBook.Author = textBox2.Text;
                    scienceBook.Price = Convert.ToDouble(textBox3.Text);
                    scienceBook.Description = textBox4.Text;
                    scienceBook.isBought = false;
                    scienceBook.isBought = false;
                    result = scienceBook;
                }
                else
                {
                    Book book = new Book();
                    book.Name = textBox1.Text;
                    book.Author = textBox2.Text;
                    book.Price = Convert.ToDouble(textBox3.Text);
                    book.isBought = false;
                    result = book;
                   
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                statusStrip1.Items.Add("Fill all fields");
            }
        }
        
    }
}
