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
    public partial class InsertBookForm : Form
    {
        public InsertBookForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlDataAdapter sda;
            MySqlCommandBuilder scb;
            string selectQuery = "select * from books";
            DataSet ds = new DataSet();

            con.Open();

            sda = new MySqlDataAdapter(selectQuery, con);
            scb = new MySqlCommandBuilder(sda);
            sda.Fill(ds, "books");

            DataRow dr = ds.Tables["books"].NewRow();

            try
            {
                dr["name"] = textBox2.Text;
                dr["publish_year"] = textBox3.Text;
                dr["writer_name"] = textBox4.Text;
                dr["quantity"] = textBox5.Text;
                dr["category_id"] = textBox6.Text;
                dr["entry_date"] = dateTimePicker1.Value.Date.ToString();

                ds.Tables["books"].Rows.Add(dr);

                int adpt = sda.Update(ds, "books");

                if (adpt == 1) MessageBox.Show("Book Added!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }

        private void InsertBookForm_Load(object sender, EventArgs e)
        {
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
