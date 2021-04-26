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
    public partial class DeleteBookForm : Form
    {
        public DeleteBookForm()
        {
            InitializeComponent();
        }

        private void DeleteBookForm_Load(object sender, EventArgs e)
        {
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Confirm to Delete the Book - " + comboBox3.Text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (choice == DialogResult.Yes)
            {

                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlDataAdapter sda;

                con.Open();

                DataTable dt = new DataTable();
                string selectQuery = "delete from books where name = '" + comboBox3.Text + "'";

                try
                {
                    sda = new MySqlDataAdapter(selectQuery, con);
                    sda.Fill(dt);

                    MessageBox.Show("Book Deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();

                this.Hide();
            }
        }
    }
}
