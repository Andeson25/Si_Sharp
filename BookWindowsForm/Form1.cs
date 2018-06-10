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
using System.Threading;

namespace BookWindowsForm
{
    public partial class Form1 : Form
    {
        List<Book> books = new List<Book>();
        String currentFileName = "";


        public Form1()
        {

            InitializeComponent();
            if (currentFileName.Equals(""))
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            books = BookService.FindAll("../../books.json");
            foreach (Book one in books)
            {
                BookGrid.Rows.Add(one.toArray());
            }
            StatusStrip.Items.Add("Books have been loaded");
        }


        private void BookGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!currentFileName.Equals(""))
            {
                var a = MessageBox.Show($"File {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]} is not saved", "File is not saved", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                
                if (a == DialogResult.OK)
                {
                    StatusStrip.Items.Clear();
                    BookService.Save(books, currentFileName);
                    StatusStrip.Items.Add($"Books have been saved to {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
                }
            }


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BookGrid.Rows.Clear();
                StatusStrip.Items.Clear();
                currentFileName = openFileDialog1.FileName;
                books = BookService.FindAll(currentFileName);
                foreach (Book one in books)
                {
                    BookGrid.Rows.Add(one.toArray());
                }
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                StatusStrip.Items.Add($"Books have been loaded from file {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
            }
        }



        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!currentFileName.Equals(""))
            {
                StatusStrip.Items.Clear();
                BookService.Save(books, currentFileName);
                StatusStrip.Items.Add($"Books have been saved to {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BookGrid.Rows.Clear();
                    StatusStrip.Items.Clear();
                    currentFileName = openFileDialog1.FileName;
                    books = BookService.FindAll(currentFileName);
                    foreach (Book one in books)
                    {
                        BookGrid.Rows.Add(one.toArray());
                    }
                    StatusStrip.Items.Add("Books have been loaded from file");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!currentFileName.Equals(""))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StatusStrip.Items.Clear();
                    currentFileName = saveFileDialog1.FileName;
                    StatusStrip.Items.Add($"Books have been saved to {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
                    BookService.Save(books, currentFileName);
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BookGrid.Rows.Clear();
                    StatusStrip.Items.Clear();
                    currentFileName = openFileDialog1.FileName;
                    books = BookService.FindAll(currentFileName);
                    foreach (Book one in books)
                    {
                        BookGrid.Rows.Add(one.toArray());
                    }
                    StatusStrip.Items.Add("Books have been loaded from file");
                }
            }
        }
    }
}
