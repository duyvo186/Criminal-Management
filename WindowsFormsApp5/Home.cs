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
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApp5
{
    public partial class Home : Form
    {
        //Connect database
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        ReportDocument cry = new ReportDocument();
        public Home()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            hienthi();
        }

      

        private void BtnAddToGiac_Click(object sender, EventArgs e)
        {
            if (txtsoTT.Text=="" ||  txtCCNT.Text == "" || txtDVTN.Text == "" || txtSoQDDTV.Text == "" || txtTenDTV.Text == "" || txtSoQDKSV.Text == "" || txtTenKSV.Text == "" || TxtKetLuan.Text == "" || dateTimePicker1.Text=="")
            {
                MessageBox.Show("Vui Long dien day du thong tin can thiet");
            }
            else
            {
                try
                {
                    String gd = "check";
                    //con.Open();
                    //string gender;
                    //if(rbtnMale.Checked)
                    //{
                    //    gender = "Male";
                    //}
                    //else
                    //{
                    //    gender = "Female";
                    //}

                    String yourcode = txtsoTT.Text;
                    QRCodeEncoder enc = new QRCodeEncoder();
                    enc.QRCodeScale = 1;
                    Bitmap qrcode = enc.Encode(yourcode);
                    pictureBox7.Image = qrcode as Image;
                    con.Open();
                    
                    cmd = new SqlCommand("insert into GiaiDoaTinBaoToGiac (SoTT,CNTC_Cungcaptin,DVtiepnhan,SoquyetdinhDTV,TenDTV,SoquyedinhKSV,TenKSV,Ketluan,Ngay_Cungcaptin,QRCode) values( '" + txtsoTT.Text + "','" + txtCCNT.Text + "','" + txtDVTN.Text + "','" + txtSoQDDTV.Text + "','" + txtTenDTV.Text + "','" + txtSoQDKSV.Text + "','" + txtTenKSV.Text + "','" + TxtKetLuan.Text + "','"+ dateTimePicker1.Text+ "',@Pic) ", con);


                    MemoryStream stream = new MemoryStream();
                    pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    cmd.Parameters.AddWithValue("@Pic", pic);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();

                    cmd = new SqlCommand("insert into  Vuan (SoTTVuan,tennguoitamgiu) values( '" + txtsoTT.Text + "','" + "day" + "') ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("insert into  BiCan (SoTTBiCan) values( '" + txtsoTT.Text + "') ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("insert into  GiaiDoan (IDVUAN,GIAIDOAN) values( '" + txtsoTT.Text + "', '" + "GD1" + "' ) ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    
                    //cmd = new SqlCommand("insert into  GiaiDoaTinBaoToGiac (GiaiDoan) values( '"  "') ", con);

                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    MessageBox.Show("them thanh cong");
                    
                    //xoaform();
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        public void xoaform()
        {
            txtsoTT.Text = "";
            txtCCNT.Text = "";
            txtDVTN.Text = "";
            txtSoQDDTV.Text = "";
            txtTenDTV.Text = "";
            txtSoQDKSV.Text = "";
            txtTenKSV.Text = "";
            TxtKetLuan.Text = "";
        }
        public void hienthi()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select *  from GiaiDoaTinBaoToGiac ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         

            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtsoTT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCCNT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDVTN.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoQDDTV.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTenDTV.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoQDKSV.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtTenKSV.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtKetLuan.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            //pictureBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            //rbtnMale.Checked = true;
            //rbtnFeMale.Checked = false;
            //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()=="Female")
            //{
            //    rbtnMale.Checked = false;
            //    rbtnFeMale.Checked = true;
            //}

        }

        private void BtnEditToGiac_Click(object sender, EventArgs e)
        {
            try
            {

                //MemoryStream stream = new MemoryStream();
                //pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] pic = stream.ToArray();
                //cmd.Parameters.AddWithValue("@Pic", pic);
                con.Open();
                cmd = new SqlCommand("update GiaiDoaTinBaoToGiac set CNTC_Cungcaptin='" + txtCCNT.Text + "',DVtiepnhan='" + txtDVTN.Text + "',SoquyetdinhDTV='" + txtSoQDDTV.Text + "',TenDTV='" + txtTenDTV.Text + "',SoquyedinhKSV='" + txtSoQDKSV.Text + "',TenKSV='" + txtTenKSV.Text + "',KetLuan='" + TxtKetLuan.Text + "',Ngay_Cungcaptin='"+ dateTimePicker1.Text + "' where SoTT='"+ ID +"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("sua thanh cong");
                hienthi();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteToGiac_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete  from GiaiDoan   where IDVUAN='" + ID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("delete  from BiCan where SoTTBiCan='" + ID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("delete  from Vuan where SoTTVuan='" + ID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("delete  from GiaiDoaTinBaoToGiac   where SoTT='" + ID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
               
                MessageBox.Show("Xoa thanh cong");
                hienthi();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            
            VuAn clickchuyenVuan = new VuAn();
            
            clickchuyenVuan.Show();
            this.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            BiCan clickchuyenBican = new BiCan();
            clickchuyenBican.Show();
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            TGXetXu clickchuyentgxetxu = new TGXetXu();
            clickchuyentgxetxu.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SearchTT clickchuyensearch = new SearchTT();
            clickchuyensearch.Show();
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt.Copy(), "GiaiDoaTinBaoToGiac");
                            workbook.SaveAs(sfd.FileName);

                        }
                        MessageBox.Show("thanh cong", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter ok = new SqlDataAdapter("select * from GiaiDoaTinBaoToGiac where SoTT = '" + txtsoTT.Text + "' ", con);
            DataSet dst = new DataSet();
            ok.Fill(dst, "GiaiDoaTinBaoToGiac");
            cry.Load("CrystalReport1.rpt");
            cry.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cry;
            con.Close();
        }
        //Image img;
        //private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        //{
        //    foreach (string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
        //    {
        //        img = Image.FromFile(pic);
        //        pictureBox7.Image = img;
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog sf = new SaveFileDialog();
        //    sf.Filter = "JPEG(*.JPEG)|*.jpeg";
        //    if(sf.ShowDialog() == DialogResult.OK)
        //    {
        //        img.Save(sf.FileName);
        //    }
        //}
    }
}
