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
    public partial class BarCode : Form
    {
        public BarCode()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Study Level Three\Amna برمجه مرئية\System\CarRentalSystem\CarRentalSystem\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void BarCodes_Click(object sender, EventArgs e)
        {
            //con.Open();
            //string Query = "select * from CarTbl where RegNum ='" + textBox1.Text + "'";
            //SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //SqlCommandBuilder buldier = new SqlCommandBuilder(da);
            //var ds = new DataSet();
            //da.Fill(ds);
            //Cars c = new Cars();

            //Zen.Barcode.CodeQrBarcodeDraw Q = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            //pictureBox1.Image = Q.Draw(10, 50);
            //con.Close();
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
    }
}
