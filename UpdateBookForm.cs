using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Library_Control
{
    public partial class UpdateBookForm : Form
    {
        public UpdateBookForm()
        {
            InitializeComponent();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            if (comboBox4.Text == "Category")
            {
                selectQuery = "SELECT name FROM category";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox5.Items.Clear();

                while (mdr.Read())
                {
                    comboBox5.Items.Add(mdr["name"].ToString());
                }
            }

            else if (comboBox4.Text == "Author")
            {
                selectQuery = "SELECT DISTINCT writer_name FROM books";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox5.Items.Clear();

                while (mdr.Read())
                {
                    comboBox5.Items.Add(mdr["writer_name"].ToString());
                }
            }

            else if (comboBox4.Text == "Entry Date")
            {
                selectQuery = "SELECT DISTINCT entry_date FROM books";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox5.Items.Clear();

                while (mdr.Read())
                {
                    comboBox5.Items.Add(mdr["entry_date"].ToString());
                }
            }

            con.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            if (comboBox4.Text == "Category")
            {
                selectQuery = "select books.name as bname from category, books where books.category_id = category.id and category.name = '" + comboBox5.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox6.Items.Clear();
                while (mdr.Read())
                {
                    comboBox6.Items.Add(mdr["bname"].ToString());
                }
            }

            else if (comboBox4.Text == "Author")
            {
                selectQuery = "select name from books where writer_name = '" + comboBox5.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox6.Items.Clear();
                while (mdr.Read())
                {
                    comboBox6.Items.Add(mdr["name"].ToString());
                }
            }

            else if (comboBox4.Text == "Entry Date")
            {
                selectQuery = "select name from books where entry_date = '" + comboBox5.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox6.Items.Clear();
                while (mdr.Read())
                {
                    comboBox6.Items.Add(mdr["name"].ToString());
                }
            }

            con.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            string bookName = comboBox6.Text;

            selectQuery = "select books.id as bid, books.name as bname, books.publish_year as pyear, books.writer_name as bauthor, books.quantity as bquantity, category.name as bcategory from books, category where books.category_id = category.id and books.name = '" + bookName + "'";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();

            textBox1.Text = mdr["bid"].ToString();
            textBox2.Text = mdr["bname"].ToString();
            textBox3.Text = mdr["pyear"].ToString();
            textBox4.Text = mdr["bauthor"].ToString();
            textBox5.Text = mdr["bquantity"].ToString();
            comboBox1.Text = mdr["bcategory"].ToString();

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery = "select id from category where name = '" + comboBox1.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                textBox6.Text = mdr["id"].ToString();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlCommand cmd;
                MySqlDataReader mdr;

                con.Open();

                string selectQuery = "update books set name = '" + textBox2.Text + "', publish_year = " + textBox3.Text + ", writer_name = '" + textBox4.Text + "', quantity = " + textBox5.Text + ", category_id = " + textBox6.Text + " where id = " + textBox1.Text;
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                MessageBox.Show("Book Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                while (mdr.Read())
                { }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBookForm_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Add("Author");
            comboBox4.Items.Add("Category");
            comboBox4.Items.Add("Entry Date");

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery = "select name from category";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            comboBox1.Items.Clear();

            while (mdr.Read())
            {
                comboBox1.Items.Add(mdr["name"].ToString());
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
        }
    }
}
