using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagement
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Form2 a = new Form2();
            //a.Show();

            string username = textBox1.Text;
            string password = textBox2.Text;

            if ((this.textBox1.Text == "Admin") && (this.textBox2.Text == "Admin"))
            {

                MessageBox.Show("you are granted with access");
                Form2 a = new Form2();
                a.Show();


            }
            else if ((this.textBox1.Text == "admin") && (this.textBox2.Text == "admin"))
            {
                MessageBox.Show("you are granted with access");
                Form2 a = new Form2();
                a.Show();
            }
            else
            {

                MessageBox.Show("you are not granted with access");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
