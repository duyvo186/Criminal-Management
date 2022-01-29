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
using CrystalDecisions.CrystalReports.Engine;
namespace WindowsFormsApp5
{
    public partial class BiCan : Form
    {
        //Connect database
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        
        int ID;
        ReportDocument cry = new ReportDocument();
        public TextBox tb1;
        public static BiCan instance;
        

                public BiCan()
        {
            InitializeComponent();
            instance = this;
            tb1 = ttnguoikhoito;
            con = new SqlConnection(path);
            hienthi();
        }



        private void BtnAddToGiac_Click(object sender, EventArgs e)
        {
            

        }

        public void xoaform()
        {
            //txtsoTT.Text = "";
            //txtCCNT.Text = "";
            //txtDVTN.Text = "";
            //txtSoQDDTV.Text = "";
            //txtTenDTV.Text = "";
            //txtSoQDKSV.Text = "";
            //txtTenKSV.Text = "";
            //TxtKetLuan.Text = "";
        }
        public void hienthi()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select *  from BiCan ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void hienthi2()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select last SoTTBiCan from BiCan  ", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(soTT.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while(da.Read())
                {
                    soTT.Text = da.GetValue(0).ToString();
                }
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //txtsoTT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txtCCNT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtDVTN.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //txtSoQDDTV.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //txtTenDTV.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //txtSoQDKSV.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //txtTenKSV.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //TxtKetLuan.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
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
            try { }
            //{

            //    //MemoryStream stream = new MemoryStream();
            //    //pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    //byte[] pic = stream.ToArray();
            //    //cmd.Parameters.AddWithValue("@Pic", pic);
            //    con.Open();
            //    cmd = new SqlCommand("update GiaiDoaTinBaoToGiac set CNTC_Cungcaptin='" + txtCCNT.Text + "',DVtiepnhan='" + txtDVTN.Text + "',SoquyetdinhDTV='" + txtSoQDDTV.Text + "',TenDTV='" + txtTenDTV.Text + "',SoquyedinhKSV='" + txtSoQDKSV.Text + "',TenKSV='" + txtTenKSV.Text + "',KetLuan='" + TxtKetLuan.Text + "',Ngay_Cungcaptin='" + dateTimePicker1.Text + "' where SoTT='" + ID + "' ", con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("sua thanh cong");
            //    hienthi();

            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteToGiac_Click(object sender, EventArgs e)
        {
           
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
            this.Close();
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 clickthongtinchitiet = new Form1();
            clickthongtinchitiet.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home clickchuyenVuan = new Home();
            clickchuyenVuan.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (soTT.Text == "" || dateTimePicker1.Text == "" || Toidanh.Text == "" || QDPheChuan.Text == "" || ttnguoikhoito.Text == "" || dieuluatKT.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Vui Long dien day du thong tin can thiet");
            }

            else
            {
                try
                {

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
                    //String yourcode = txtsoTT.Text;

                    //Bitmap qrcode = enc.Encode(yourcode);
                    //pictureBox7.Image = image as Image;

                    con.Open();
                    cmd = new SqlCommand("insert into BiCan  (SoTTBiCan,dateQDkhoito,ToidanhKT,QDPheChuan,TTNguoikhoito,DLKhoiTo,ThoiGianTamGiam) values( '" + soTT.Text + "','" + dateTimePicker1.Text + "','" + Toidanh.Text + "','" + QDPheChuan.Text + "','" + ttnguoikhoito.Text + "','" + dieuluatKT.Text + "','" + dateTimePicker2.Text + "') ", con);


           




                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("them thanh cong");

                    xoaform();
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public Image CovertByteToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            

           
            
                
                if(dt!= null)
            {
                DataRow row = dt.Rows[e.RowIndex];
                if(!Convert.IsDBNull(row["image"]))
                {
                    pictureBox7.Image = CovertByteToImage((byte[])row["image"]);
                }
                
            }
           
                ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                soTT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Toidanh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                QDPheChuan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                ttnguoikhoito.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dieuluatKT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].ToString();

            
















            //rbtnMale.Checked = true;
            //rbtnFeMale.Checked = false;
            //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Female")
            //{
            //    rbtnMale.Checked = false;
            //    rbtnFeMale.Checked = true;
            //}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try 
            {

                //MemoryStream stream = new MemoryStream();
                //pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] pic = stream.ToArray();
                //cmd.Parameters.AddWithValue("@Pic", pic);
                con.Open();
                cmd = new SqlCommand("update BiCan set dateQDkhoito='" + dateTimePicker1.Text + "',ToidanhKT='" + Toidanh.Text + "',QDPheChuan='" + QDPheChuan.Text + "',TTNguoikhoito='" + ttnguoikhoito.Text + "',DLKhoiTo='" + dieuluatKT.Text + "',ThoiGianTamGiam='" + dateTimePicker2.Text + "',FileName='"+textBox1.Text+"',image=@Pic where SoTTBiCan='" + ID + "' ", con);
                MemoryStream stream = new MemoryStream();
                pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@Pic", pic);

                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("update GiaiDoan set GIAIDOAN='"+ "GD3" +"'  where IDVUAN='" + ID + "' ", con);
               
                cmd.ExecuteNonQuery();
                con.Close();
               
                MessageBox.Show("sua thanh cong");
                hienthi();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from BiCan where SoTTBiCan='" + ID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Xoa thanh cong");
                hienthi();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

        }
        //public void Insert(string filename, byte[] image)
        //{
        //    if (con.State == ConnectionState.Closed)
        //        con.Open();
        //    cmd = new SqlCommand("insert into BiCan(SoTTBiCanfilename,image) values('" + textBox1.Text +"','"+ pictureBox7.Text + "')")
        //}
        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*.jpeg", Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox7.Image = Image.FromFile(ofd.FileName);
                    textBox1.Text = ofd.FileName;
                    
                }
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        //private void soTT_TextChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    cmd = new SqlCommand("Select last SoTTBiCan from BiCan where SoTTBiCan=@SoTTBiCan", con);
        //    cmd.Parameters.AddWithValue("@SoTTBiCan", int.Parse(soTT.Text));
        //    textBox1.Text = da.GetValue(0).ToString();
        //}
    }
}
