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

namespace WindowsFormsApp5
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True");
            string query = "Select * from login Where username = '"+txtusername.Text.Trim() + "'and password = '" + txtpw.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Home objfrmLogin = new Home();
                objfrmLogin.Show();
            }
            else
            {
                MessageBox.Show("Kiem tra tai khoan mat khau lai");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (txtpw.PasswordChar == '*')
            {
                button3.BringToFront();
                txtpw.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (txtpw.PasswordChar == '\0')
            {
                button3.BringToFront();
                txtpw.PasswordChar = '*';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormForGot ok = new FormForGot();
            ok.Show();
            this.Close();
        }
    }
}
