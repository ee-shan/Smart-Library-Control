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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlDataAdapter sda;

            con.Open();

            DataTable dt = new DataTable();
            string selectQuery = "insert into category (name) values ('" + textBox1.Text + "')";

            try
            {
                sda = new MySqlDataAdapter(selectQuery, con);
                sda.Fill(dt);

                MessageBox.Show("Category Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();

            this.Close();
        }
    }
}
