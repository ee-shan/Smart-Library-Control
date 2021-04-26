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
    public partial class BookViewer : Form
    {
        public BookViewer()
        {
            InitializeComponent();
        }

        private void BookViewer_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery = "select count(name) from books";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();
            label2.Text += mdr["count(name)"].ToString();

            con.Close();

            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2 = "select sum(quantity) from books";
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            mdr2.Read();
            label3.Text += mdr2["sum(quantity)"].ToString();

            con2.Close();

            comboBox1.Items.Add("Author");
            comboBox1.Items.Add("Category");
            comboBox1.Items.Add("Entry Date");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            if (comboBox1.Text == "Category")
            {
                selectQuery = "SELECT name FROM category";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();

                while (mdr.Read())
                {
                    comboBox2.Items.Add(mdr["name"].ToString());
                }
            }

            else if (comboBox1.Text == "Author")
            {
                selectQuery = "SELECT DISTINCT writer_name FROM books";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();

                while (mdr.Read())
                {
                    comboBox2.Items.Add(mdr["writer_name"].ToString());
                }
            }

            else if (comboBox1.Text == "Entry Date")
            {
                selectQuery = "SELECT DISTINCT entry_date FROM books";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();

                while (mdr.Read())
                {
                    comboBox2.Items.Add(mdr["entry_date"].ToString());
                }
            }

            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            if (comboBox1.Text == "Category")
            {
                selectQuery = "select books.id as bid, books.name as bname, books.writer_name as author, books.publish_year as pyear, books.quantity as bquantity, category.name as cname from books, category where books.category_id = category.id and category.name = '" + comboBox2.Text + "'";
                
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["bid"].ToString();
                    item.SubItems.Add(mdr["bname"].ToString());
                    item.SubItems.Add(mdr["author"].ToString());
                    item.SubItems.Add(mdr["pyear"].ToString());
                    item.SubItems.Add(mdr["bquantity"].ToString());
                    item.SubItems.Add(mdr["cname"].ToString());

                    listView1.Items.Add(item);
                }
            }

            else if (comboBox1.Text == "Author")
            {
                selectQuery = "select books.id as bid, books.name as bname, books.writer_name as author, books.publish_year as pyear, books.quantity as bquantity, category.name as cname from books, category where books.category_id = category.id and books.writer_name = '" + comboBox2.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["bid"].ToString();
                    item.SubItems.Add(mdr["bname"].ToString());
                    item.SubItems.Add(mdr["author"].ToString());
                    item.SubItems.Add(mdr["pyear"].ToString());
                    item.SubItems.Add(mdr["bquantity"].ToString());
                    item.SubItems.Add(mdr["cname"].ToString());

                    listView1.Items.Add(item);
                }
            }

            else if (comboBox1.Text == "Entry Date")
            {
                selectQuery = "select books.id as bid, books.name as bname, books.writer_name as author, books.publish_year as pyear, books.quantity as bquantity, category.name as cname from books, category where books.category_id = category.id and books.entry_date = '" + comboBox2.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["bid"].ToString();
                    item.SubItems.Add(mdr["bname"].ToString());
                    item.SubItems.Add(mdr["author"].ToString());
                    item.SubItems.Add(mdr["pyear"].ToString());
                    item.SubItems.Add(mdr["bquantity"].ToString());
                    item.SubItems.Add(mdr["cname"].ToString());

                    listView1.Items.Add(item);
                }
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            selectQuery = "select books.id as bid, books.name as bname, books.writer_name as author, books.publish_year as pyear, books.quantity as bquantity, category.name as cname from books, category where books.category_id = category.id";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            listView1.Items.Clear();
            while (mdr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = mdr["bid"].ToString();
                item.SubItems.Add(mdr["bname"].ToString());
                item.SubItems.Add(mdr["author"].ToString());
                item.SubItems.Add(mdr["pyear"].ToString());
                item.SubItems.Add(mdr["bquantity"].ToString());
                item.SubItems.Add(mdr["cname"].ToString());

                listView1.Items.Add(item);
            }

            con.Close();
        }
    }
}
