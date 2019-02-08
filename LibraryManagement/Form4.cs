using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace LibraryManagement
{
    public partial class Form4 : Form
    {
        string pwd;
        string wanted_path;

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = Class1.GetRandomPassword(20);
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files(*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";
            if(result==DialogResult.OK)//test result
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string img_path;
            File.Copy(openFileDialog1.FileName, wanted_path + "\\stu_images\\" + pwd + ".jpg");
            img_path = "stduent_images\\" + pwd + ".jpg";
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO stu_info 
                     (student_name,student_image,student_enrollment_no,student_department,student_sem,student_contact,student_email)
                   VALUES('" + textBox1.Text + "','" + pictureBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved......!");
        }
    }
    }

