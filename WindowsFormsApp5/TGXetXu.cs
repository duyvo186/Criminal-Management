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
using System.Configuration;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.IO;
using ClosedXML.Excel;
using ClosedXML.Attributes;
using ClosedXML.Utils;
using ZXing;
using ZXing.QrCode;

namespace WindowsFormsApp5
{
    public partial class TGXetXu : Form
    {
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";
        
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;


        public TGXetXu()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            hienthi();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home clickchuyenVuan = new Home();
            clickchuyenVuan.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VuAn clickchuyenVuan = new VuAn();
            clickchuyenVuan.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BiCan clickchuyenVuan = new BiCan();
            clickchuyenVuan.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SearchTT clickchuyenVuan = new SearchTT();
            clickchuyenVuan.Show();
            this.Close();
        }
        public void hienthi()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select GiaiDoaTinBaoToGiac.SoTT,GiaiDoan.IDVUAN,BiCan.SoTTBiCan,Vuan.SoTTVuan,GiaiDoan.GIAIDOAN,GiaiDoan.THOIGIANDEMNGUOC,GiaiDoaTinBaoToGiac.SoquyetdinhDTV,GiaiDoaTinBaoToGiac.SoquyedinhKSV,Vuan.QDtamgiu,BiCan.TTNguoikhoito   from GiaiDoaTinBaoToGiac Join GiaiDoan on GiaiDoaTinBaoToGiac.SoTt=GiaiDoan.IDVUAN Join BiCan on GiaiDoaTinBaoToGiac.SoTt=BiCan.SoTTBiCan Join Vuan on GiaiDoaTinBaoToGiac.SoTt=Vuan.SoTTVuan order by SoTT  ", con);
                
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[5].Visible = false;
                //dataGridView1.Columns[6].Visible = false;
                //dataGridView1.Columns[7].Visible = false;
                con.Close();
                //con.Open();
                //adpt = new SqlDataAdapter("select *  from GiaiDoaTinBaoToGiac ", con);

                //adpt.Fill(dt);
                //dataGridView1.DataSource = dt;
                ////dataGridView1.Columns[5].Visible = false;
                ////dataGridView1.Columns[6].Visible = false;
                ////dataGridView1.Columns[7].Visible = false;
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                con.Open();
            
                SqlCommand cmd = new SqlCommand("Select  from GiaiDoaTinBaoToGiac join GiaiDoan on GiaiDoaTinBaoToGiac.SoTt=GiaiDoan.IDVUAN Order by SoTT ", con);
                cmd.Parameters.AddWithValue("SoTT", int.Parse(textBox1.Text));
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
               
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            
                
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            
                button1.PerformClick();
            
               

                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TGXetXu_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
