using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class txtPasverìy : Form
    {
        string username = FormForGot.to;

        public txtPasverìy()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtPas.Text == txtPasverify.Text)
            {
                
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE login SET [password] = '" + txtPasverify.Text + "' WHERE username='" + username + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reset Thành Công");
            }
            else
            {
                MessageBox.Show("the new password do not match so enter same password");
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            frmLogin ok = new frmLogin();
            ok.Show();
        }
    }
}
