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
    public partial class AllUser : Form
    {
        public AllUser()
        {
            InitializeComponent();
        }

        private void AllUser_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=tinylibrary");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            try
            {
                con.Open();

                string selectQuery = "select id, name from users";

                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (mdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mdr["id"].ToString();
                    item.SubItems.Add(mdr["name"].ToString());

                    listView1.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }
    }
}
