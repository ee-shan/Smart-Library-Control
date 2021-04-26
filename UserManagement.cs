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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageOptionsForm f = new ManageOptionsForm();
            f.Show();
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

        private void UserManagement_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Author");
            comboBox1.Items.Add("Category");
            comboBox1.Items.Add("Entry Date");
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
                selectQuery = "select books.name as bname from books, category where books.category_id = category.id and category.name = '" + comboBox2.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox3.Items.Clear();
                while (mdr.Read())
                {
                    comboBox3.Items.Add(mdr["bname"].ToString());
                }
            }

            else if (comboBox1.Text == "Author")
            {
                selectQuery = "select name from books where writer_name = '" + comboBox2.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox3.Items.Clear();
                while (mdr.Read())
                {
                    comboBox3.Items.Add(mdr["name"].ToString());
                }
            }

            else if (comboBox1.Text == "Entry Date")
            {
                selectQuery = "select name from books where entry_date = '" + comboBox2.Text + "'";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                comboBox3.Items.Clear();
                while (mdr.Read())
                {
                    comboBox3.Items.Add(mdr["name"].ToString());
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlCommand cmd;
                MySqlDataReader mdr;

                con.Open();

                string selectQuery = "update books set quantity = quantity - 1 where id = '" + textBox3.Text + "'";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                MessageBox.Show("Lend Successful! Click Toggle to view the updated history.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                while (mdr.Read())
                { }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlCommand cmd2;
                MySqlDataReader mdr2;

                con2.Open();

                string selectQuery2 = "insert into history values(" + textBox1.Text + ", " + textBox3.Text + ", '" + dateTimePicker1.Text + "', 'not returned', '')";
                cmd2 = new MySqlCommand(selectQuery2, con2);
                mdr2 = cmd2.ExecuteReader();

                while (mdr2.Read())
                { }

                con2.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlCommand cmd;
                MySqlDataReader mdr;

                con.Open();

                string selectQuery = "update books set quantity = quantity + 1 where id = '" + textBox3.Text + "'";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                MessageBox.Show("Returned Successfully! Click Toggle to view the updated history.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                while (mdr.Read())
                { }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlCommand cmd2;
                MySqlDataReader mdr2;

                con2.Open();

                string selectQuery2 = "update history set return_state = 'returned', return_date = '" + dateTimePicker1.Text + "' where user_id = " + textBox1.Text + " and book_id = " + textBox3.Text + " and return_state = 'not returned'";
                cmd2 = new MySqlCommand(selectQuery2, con2);
                mdr2 = cmd2.ExecuteReader();

                while (mdr2.Read())
                { }

                con2.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            string bookName = comboBox3.Text;

            selectQuery = "select id from books where name = '" + bookName + "'";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();

            textBox3.Text = mdr["id"].ToString();

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            try
            {
                con.Open();

                string selectQuery = "SELECT books.id AS bid, books.name AS bname, books.writer_name AS author, history.lend_date AS ldate, history.return_state AS rstate, history.return_date AS rdate FROM history, users, books WHERE history.user_id = users.id AND history.user_id = " + textBox1.Text + " AND history.book_id = books.id";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["bid"].ToString();
                    item.SubItems.Add(mdr["bname"].ToString());
                    item.SubItems.Add(mdr["author"].ToString());
                    item.SubItems.Add(mdr["ldate"].ToString());
                    item.SubItems.Add(mdr["rstate"].ToString());
                    item.SubItems.Add(mdr["rdate"].ToString());

                    listView1.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();

            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2 = "select name from users where id = " + textBox1.Text;
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            mdr2.Read();
            label7.Text = "User Toggled: " + mdr2["name"].ToString();

            con2.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddUser f = new AddUser();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllUser f = new AllUser();
            f.Show();
        }
    }
}
