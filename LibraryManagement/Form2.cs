using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace LibraryManagement
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO new_books_add 
                     (books_name,books_author_name,books_publication_name,books_purchase,books_price,books_qty)
                   VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved......!");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }



        private void Form2_Load(object sender, EventArgs e)
        {
            Display();

        }
        void Display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select * from books_add";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            s.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE  books_add 
            SET books_name='" + textBox1.Text + "',books_author_name='" + textBox2.Text + "',books_publication_name='" + textBox3.Text + "',books_purchase = '" + dateTimePicker1.Value.ToString() + "' ,books_price = '" + textBox5.Text + "' ,books_qty='" + textBox6.Text + "' WHERE( books_name='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated......!");
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobile where (Mobile like'" + textBox5.Text + "%') or (First like'" + textBox5.Text + "%') " +
                "or (Last like'" + textBox5.Text + "%') or (Email like'" + textBox5.Text + "%')  " +
                "or (Category like'" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["books_name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["books_author_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["books_publication_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["books_purchase"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["books_price"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["books_qty"].ToString();



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM books_add 
                    WHERE (books_name='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully......!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select * from books_add where books_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    

