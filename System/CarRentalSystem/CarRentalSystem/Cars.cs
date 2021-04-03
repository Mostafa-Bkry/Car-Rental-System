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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
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
            string Query = "select * from CarTbl";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            SqlCommandBuilder buldier = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBoxRNo.Text == "" || textBoxBrand.Text == "" || textBoxModel.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("Check Entered Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into CarTbl values(" + textBoxRNo.Text + ",'" + textBoxBrand.Text + "','"
                        + textBoxModel.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBoxPrice.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car is successfully added to system DB");
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

        private void Cars_Load(object sender, EventArgs e)
        {
            populate();
        }

        public void CarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRNo.Text = CarDGV.SelectedRows[0].Cells[0].Value.ToString();
            textBoxBrand.Text = CarDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxModel.Text = CarDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = CarDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxPrice.Text = CarDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (textBoxRNo.Text == "")
            {
                MessageBox.Show("Check Entered Information");
                textBoxRNo.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete from CarTbl where RegNum =" + textBoxRNo.Text + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car is successfully deleted from system DB");
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
            if (textBoxRNo.Text == "" || textBoxBrand.Text == "" || textBoxModel.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("Check Entered Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "update CarTbl set Brand ='" + textBoxBrand.Text + "',Model ='" + textBoxModel.Text +
                        "',Available ='" + comboBox1.SelectedItem.ToString() + "',Price ='" + textBoxPrice.Text + 
                        "'where RegNum = " + textBoxRNo.Text + ";";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car is successfully updated in system DB");
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
    }
}
