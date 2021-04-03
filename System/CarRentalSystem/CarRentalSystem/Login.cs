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

namespace CarRentalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Study Level Three\Amna برمجه مرئية\System\CarRentalSystem\CarRentalSystem\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string Query = "select * from userTbl where Username ='" + textBox2.Text.Trim() + "' and Password ='" + textBox1.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            //if (textBox2.Text != "Mostafa" && textBox1.Text != "212")
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Welcome " + textBox2.Text + " To System Management");
                sys s = new sys();
                s.Show();
                this.Hide();
            }
            else
            {
               
                MessageBox.Show("Check your Name or Password");
            }
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
