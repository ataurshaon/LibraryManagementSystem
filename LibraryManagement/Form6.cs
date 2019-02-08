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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 a = new Form7();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select * from stu_info where student_enrollment_no ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("this enrollment not found");
            }
            else
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["student_name"].ToString();
                    textBox3.Text = dr["student_department"].ToString();
                    textBox4.Text = dr["student_sem"].ToString();
                    textBox5.Text = dr["student_contact"].ToString();
                    textBox6.Text = dr["student_email"].ToString();
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
