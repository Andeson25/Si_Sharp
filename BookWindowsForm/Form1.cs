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

        addForm addForm = new addForm();
        Boolean isSaved = false;

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

        }



        private void ClearTextBoxes()
        {
            addForm.result = new Book();
            addForm.textBox1.Text = "";
            addForm.textBox2.Text = "";
            addForm.textBox3.Text = "";
            addForm.textBox4.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (books.Count == 0)
                {
                    addForm.result.Id = 1;
                    books.Add(addForm.result);
                }
                else
                {
                    addForm.result.Id = books[books.Count-1].Id + 1;
                    books.Add(addForm.result);
                }

           

                BookGrid.Rows.Clear();
                foreach (Book one in books)
                {
                    BookGrid.Rows.Add(one.toArray());
                }

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                isSaved = false;


             
            }
            ClearTextBoxes();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( !isSaved && BookGrid.Rows.Count != 0)
            {
                var a = MessageBox.Show($"File {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]} is not saved", "File is not saved", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (a == DialogResult.OK&& currentFileName != ""&& BookGrid.Rows.Count != 0)
                {
                    StatusStrip.Items.Clear();
                    BookService.Save(books, currentFileName);
                    StatusStrip.Items.Add($"Books have been saved to {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
                }
                if (currentFileName==""&&a == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK && BookGrid.Rows.Count!=0)
                {
                    StatusStrip.Items.Clear();
                    currentFileName = saveFileDialog1.FileName;
                    isSaved = true;
                    StatusStrip.Items.Add($"Books have been saved to {currentFileName.Split('\\')[currentFileName.Split('\\').Length - 1]}");
                    BookService.Save(books, currentFileName);
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
                isSaved = false;
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
                isSaved = true;
                saveToolStripMenuItem.Enabled = false;
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
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                    isSaved = false;
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
                    isSaved = true;
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
                    isSaved = false;
                    StatusStrip.Items.Add("Books have been loaded from file");
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow one in BookGrid.SelectedRows)
                {
                    books.RemoveAt(one.Index);

                }
                BookGrid.Rows.Clear();
                foreach (Book one in books)
                {
                    BookGrid.Rows.Add(one.toArray());
                }
                isSaved = false;
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
