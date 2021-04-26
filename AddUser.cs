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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Confirm to Add?", "Confirmation", MessageBoxButtons.YesNo);

            if (choice == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlDataAdapter sda;

                con.Open();

                DataTable dt = new DataTable();
                string selectQuery = "insert into users(name) values ('" + textBox2.Text + "')";

                try
                {
                    sda = new MySqlDataAdapter(selectQuery, con);
                    sda.Fill(dt);

                    MessageBox.Show("User Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();
            }
        }
    }
}
