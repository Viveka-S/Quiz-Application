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
    public partial class Form2 : Form
    {
        DataSet ds = new DataSet();
        int count;
        int quesNo = 1;
        int itr = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            cn.Open();

            answer_1.Checked = false;
            answer_2.Checked = false;
            answer_3.Checked = false;
            answer_4.Checked = false;

            SqlDataAdapter da = new SqlDataAdapter("select * from question", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "question");
            label2.Text = ds.Tables[0].Rows[0]["qno"].ToString();
            Questions.Text = ds.Tables[0].Rows[0]["question"].ToString();
            answer_1.Text = ds.Tables[0].Rows[0]["ans1"].ToString();
            answer_2.Text = ds.Tables[0].Rows[0]["ans2"].ToString();
            answer_3.Text = ds.Tables[0].Rows[0]["ans3"].ToString();
            answer_4.Text = ds.Tables[0].Rows[0]["ans4"].ToString();
            count = ds.Tables[0].Rows.Count;
            cn.Close();
        }

       

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            sc.Open();
            com.Connection = sc;
            if (answer_3.Checked == true)
            {
                com.CommandText = ("update question set selcetedans=3 where qno='" + quesNo + "';");
                com.ExecuteNonQuery();
            }
            sc.Close();


        }

        private void answer_1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            sc.Open();
            com.Connection = sc;
            if (answer_1.Checked == true)
            {
                com.CommandText = ("update question set selcetedans=1 where qno='" + quesNo + "';");
                com.ExecuteNonQuery();
            }
            sc.Close();


        }

        private void answer_2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            sc.Open();
            com.Connection = sc;
            if (answer_2.Checked == true)
            {
                com.CommandText = ("update question set selcetedans=2 where qno='" + quesNo + "';");
                com.ExecuteNonQuery();
            }
            sc.Close();

        }

        private void answer_4_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            sc.Open();
            com.Connection = sc;
            if (answer_4.Checked == true)
            {
                com.CommandText = ("update question set selcetedans=4 where qno='" + quesNo + "';");
                com.ExecuteNonQuery();
            }
            sc.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            answer_1.Checked = false;
            answer_2.Checked = false;
            answer_3.Checked = false;
            answer_4.Checked = false;
            SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from question", cn);
            da.Fill(ds, "question");
            if (ds != null && i < c)
            {
                label2.Text = ds.Tables[0].Rows[itr]["qno"].ToString();
                Questions.Text = ds.Tables[0].Rows[itr]["question"].ToString();
                answer_1.Text = ds.Tables[0].Rows[itr]["ans1"].ToString();
                answer_2.Text = ds.Tables[0].Rows[itr]["ans2"].ToString();
                answer_3.Text = ds.Tables[0].Rows[itr]["ans3"].ToString();
                answer_4.Text = ds.Tables[0].Rows[itr]["ans4"].ToString();
                itr = itr + 1;
                quesNo = quesNo + 1;

                if (itr == count)
                {
                    button2.Text = "submit";

                }
            }

            else
            {
                this.Hide();
                Form3 ss = new Form3();
                ss.Show();
            }

            cn.Close();

        }
    }
}
