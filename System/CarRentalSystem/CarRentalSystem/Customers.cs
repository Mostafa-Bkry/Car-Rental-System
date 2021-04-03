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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            sys s = new sys();
            s.Show();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Study Level Three\Amna برمجه مرئية\System\CarRentalSystem\CarRentalSystem\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            string Query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            SqlCommandBuilder buldier = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text == "" || textBoxname.Text == "" || textBoxaddr.Text == "" || textBoxphone.Text == "")
            {
                MessageBox.Show("Check Entered Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into CustomerTbl values(" + textBoxid.Text + ",'" + textBoxname.Text + "','" 
                        + textBoxaddr.Text + "','"+ textBoxphone.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer is successfully added to system DB");
                    con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    con.Close();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text == "")
            {
                MessageBox.Show("Check Entered Information");
                textBoxid.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete from CustomerTbl where CustId =" + textBoxid.Text + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer is successfully deleted from system DB");
                    con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    con.Close();
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text == "" || textBoxname.Text == "" || textBoxaddr.Text == "" || textBoxphone.Text == "")
            {
                MessageBox.Show("Check Entered Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "update CustomerTbl set CustName ='" + textBoxname.Text + "',CustAdd ='" + textBoxaddr.Text + 
                        "',Phone ='"+ textBoxphone.Text + "'where CustId = " + textBoxid.Text + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer is successfully updated in system DB");
                    con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    con.Close();
                }
            }
        }

        private void CustDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = CustDGV.SelectedRows[0].Cells[0].Value.ToString();
            textBoxname.Text = CustDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxaddr.Text = CustDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBoxphone.Text = CustDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
