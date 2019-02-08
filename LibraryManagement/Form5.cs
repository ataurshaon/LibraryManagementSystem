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
using System.IO;

namespace LibraryManagement
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stu_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from stu_info where student_name like('%"+textBox1.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                    }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i;
            //i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stu_info";
                // where id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["student_name"].ToString();
                textBox4.Text = dr["student_enrollment_no"].ToString();
                textBox6.Text = dr["student_department"].ToString();
                textBox3.Text = dr["student_sem"].ToString();
                textBox5.Text = dr["student_contact"].ToString();
                textBox7.Text = dr["student_email"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"update stu_info set student_name='"+textBox2.Text+"',student_enrollment_no='"+textBox4.Text+"',student_department='"+textBox6.Text+"',student_sem='"+textBox3.Text+"',student_contact='"+textBox5.Text+"',student_email='"+textBox7.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
        }
    }
}
