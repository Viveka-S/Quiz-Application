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

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            sc.Open();
            com.Connection = sc;
            com.CommandText = ("insert into login (username,password) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "');");
            com.ExecuteNonQuery();
            sc.Close();
            this.Hide();
            Form2 ss = new Form2();
            ss.Show();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            SqlDataAdapter sda= new SqlDataAdapter("select count(*) from login where username='"+ textBox1.Text +"'and password ='" + textBox2.Text + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form2 ss = new Form2();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please check your user name and password");
            }
        }

        
    }
}
