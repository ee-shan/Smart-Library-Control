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
    public partial class ManagerControlForm : Form
    {
        public ManagerControlForm()
        {
            InitializeComponent();
        }

        private void ManagerControlForm_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            try
            {
                con.Open();

                string selectQuery = "select Name, username from managers";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["Name"].ToString();
                    item.SubItems.Add(mdr["username"].ToString());

                    listView1.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Confirm to Add?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (choice == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlDataAdapter sda;

                con.Open();

                DataTable dt = new DataTable();
                string selectQuery = "insert into managers values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";

                try
                {
                    sda = new MySqlDataAdapter(selectQuery, con);
                    sda.Fill(dt);

                    MessageBox.Show("Manager Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();

                this.Close();
                ManagerControlForm f = new ManagerControlForm();
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Confirm to Remove?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (choice == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
                MySqlDataAdapter sda;

                con.Open();

                DataTable dt = new DataTable();
                string selectQuery = "delete from managers where username = '" + textBox4.Text + "'";

                try
                {
                    sda = new MySqlDataAdapter(selectQuery, con);
                    sda.Fill(dt);

                    MessageBox.Show("Manager Removed", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();

                this.Close();
                ManagerControlForm f = new ManagerControlForm();
                f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm f = new AdminForm();
            f.Show();
        }
    }
}
