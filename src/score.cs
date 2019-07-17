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
    public partial class Form3 : Form
    {
        DataSet ds = new DataSet();
        int selectedAns, correctAns;
        int score = 0;
        int itr = 0;
        int count;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-GMEFK9D8\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;");
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from question", cn);
            da.Fill(ds, "question");
            count = ds.Tables[0].Rows.Count;
            while (itr < count)
            {
                selectedAns = Convert.ToInt32(ds.Tables[0].Rows[j]["selcetedans"].ToString());
                correctAns = Convert.ToInt32(ds.Tables[0].Rows[j]["correctans"].ToString());
               
                if (selectedAns == correctAns)
                {
                    score = score + 1;
                }
               itr++;
            }
            label3.Text = " " +score+ "/" +c+ "";
            cn.Close(); 
        }
    }
}
