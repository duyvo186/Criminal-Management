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
namespace WindowsFormsApp5
{
        public partial class Form1 : Form
    {
        //Connect database
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        public static Form1 instance;
        public TextBox tb1;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            tb1 = hovaten;
            con = new SqlConnection(path);
            hienthi();
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void BtnAddToGiac_Click(object sender, EventArgs e)
        {
           
        }
        public void xoaform()
        {
            sottbican.Text = "";
            hovaten.Text = "";
            noisinh.Text = "";
            quequan.Text = "";
            nghenghiep.Text = "";
            dantoc.Text = "";
            tongiao.Text = "";
            socmnd.Text = "";
            noicap.Text = "";
            thuongtru.Text = "";
            tamtru.Text = "";
         
          

        }
        public void hienthi()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from formBiCan ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            VuAn clickchuyenVuan = new VuAn();
            clickchuyenVuan.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BiCan clickchuyenBican = new BiCan();
            clickchuyenBican.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            TGXetXu clickchuyentgxetxu = new TGXetXu();
            clickchuyentgxetxu.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SearchTT clickchuyensearch = new SearchTT();
            clickchuyensearch.Show();
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

        private void label16_Click(object sender, EventArgs e)
        {
            BiCan clickquayve = new BiCan();
            clickquayve.Show();
        }

        

        private void tamtru_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddVuAn_Click(object sender, EventArgs e)
        {
            
            if (hovaten.Text == "" || quequan.Text == "" || noisinh.Text == "" || nghenghiep.Text == "" || dantoc.Text == "" || tongiao.Text == "" || socmnd.Text == "" || noicap.Text == "" || thuongtru.Text == "")
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

                    con.Open();
                    cmd = new SqlCommand("insert into formBiCan (SoTTBiCan,HOTENBICAN,Datenamsinh,NOISINH,QueQuan,NgheNghiep,DanToc,TonGiao,SoCMND,NoiCap,ThuongTru,TamTru) values( '" + sottbican.Text + "','" + hovaten.Text + "','"+ dateTimePicker2.Text +"','" + noisinh.Text + "','" + quequan.Text + "','" + nghenghiep.Text + "','" + dantoc.Text + "','" + tongiao.Text + "','" + socmnd.Text + "','" + noicap.Text + "','" + thuongtru.Text + "','" + tamtru.Text + "') ", con);

                    


                    cmd.ExecuteNonQuery();
                    con.Close();

                    
                    MessageBox.Show("them thanh cong");

                    
                    hienthi();
                    BiCan.instance.tb1.Text = hovaten.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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
                cmd = new SqlCommand("update formBiCan set HOTENBICAN='" + hovaten.Text + "',Datenamsinh='" + dateTimePicker2.Text + "',NOISINH='" + noisinh.Text + "',QueQuan='" + quequan.Text + "',NgheNghiep='" + nghenghiep.Text + "',DanToc='" + dantoc.Text + "',TonGiao='" + tongiao.Text + "',SoCMND='" + socmnd.Text + "',NoiCap='" + noicap.Text + "',ThuongTru='" + thuongtru.Text + "',TamTru='" + tamtru.Text + "' where SoTTBiCan='" + ID + "' ", con);
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

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {


            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            //pictureBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            //rbtnMale.Checked = true;
            //rbtnFeMale.Checked = false;
            //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()=="Female")
            //{
            //    rbtnMale.Checked = false;
            //    rbtnFeMale.Checked = true;
            //}
            sottbican.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); ;
            hovaten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); ;
            noisinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); ;
            quequan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); ;
            nghenghiep.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); ;
            dantoc.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); ;
            tongiao.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); ;
            socmnd.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); ;
            noicap.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); ;
            thuongtru.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); ;
            tamtru.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString(); ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from formBiCan where SoTT='" + ID + "'", con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
