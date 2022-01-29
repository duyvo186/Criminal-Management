using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using ZXing;

namespace WindowsFormsApp5
{
    public partial class SearchTT : Form
    {
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        public SearchTT()
        {
            
            InitializeComponent();
            con = new SqlConnection(path);
            hienthi();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           


        }
        private void FromLoad(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbodevice.Items.Add(filterInfo.Name);
            cbodevice.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbodevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_newFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox8.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void SearchTT_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox8.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox8.Image);

                if(result != null)
                {
                    textBox1.Text = result.ToString();
                    Home oke = new Home();
                    
                    con.Open();
                    
                    SqlCommand cmd = new SqlCommand("Select * from GiaiDoan where IDVUAN=@IDVUAN ", con);
                    cmd.Parameters.AddWithValue("@IDVUAN", int.Parse(textBox1.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home clickchuyenVuan = new Home();
            clickchuyenVuan.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VuAn clickchuyenVuan = new VuAn();
            clickchuyenVuan.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BiCan clickchuyenVuan = new BiCan();
            clickchuyenVuan.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SearchTT clickchuyenVuan = new SearchTT();
            clickchuyenVuan.Show();
        }
    }
}
