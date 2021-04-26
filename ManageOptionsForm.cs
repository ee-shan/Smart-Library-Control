using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Library_Control
{
    public partial class ManageOptionsForm : Form
    {
        public ManageOptionsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertBookForm f = new InsertBookForm();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteBookForm f = new DeleteBookForm();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookViewer f = new BookViewer();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerForm f = new ManagerForm();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddCategory f = new AddCategory();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBookForm f = new UpdateBookForm();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagement f = new UserManagement();
            f.Show();
        }
    }
}
