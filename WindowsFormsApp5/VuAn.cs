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


namespace WindowsFormsApp5
{
    public partial class VuAn : Form
    {
        //Connect database
        string path = @"Data Source=LAPTOP-IIUV287C\SQLEXPRESS;Initial Catalog=Quanlyanhinhsu;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        public VuAn()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            hienthi();
        }



        private void BtnAddVuAn_Click(object sender, EventArgs e)
        {
            

        }
        public void xoaform()
        {
            txtSoTT.Text = "";
            QDTamGiu.Text = "";
            txtTenTamGiu.Text = "";
            dateTimePicker3.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txtLyDoTamGiu.Text = "";
            

        }
       

        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{


        //    ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        //    txtSoTT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    txtQDTamGiu.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    txtTenTamGiu.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //    txtNgayKhoiTo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        //    dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        //    dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        //    txtLyDoTamGiuText = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        //    TxtGhiChu.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

        //    pictureBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        //    //rbtnMale.Checked = true;
        //    //rbtnFeMale.Checked = false;
        //    //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()=="Female")
        //    //{
        //    //    rbtnMale.Checked = false;
        //    //    rbtnFeMale.Checked = true;
        //    //}

        //}

        //private void BtnEditToGiac_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        MemoryStream stream = new MemoryStream();
        //        pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        byte[] pic = stream.ToArray();
        //        cmd.Parameters.AddWithValue("@Pic", pic);
        //        con.Open();
        //        cmd = new SqlCommand("update GiaiDoaTinBaoToGiac set QDtamgiu='" + txtQDTamGiu.Text + "',Tennguoitamgiu='" + txtTenTamGiu.Text + "',QDgiahantamgiulan1='" + dateTimePicker1.Text + "',QDgiahantamgiulan2='" + dateTimePicker2.Text + "',Lydotamgiu='" + txtLyDoTamGiu.Text + "',Ghichu='" + TxtGhiChu.Text + "',QRCode=@Pic where SoTT='" + ID + "' ", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        MessageBox.Show("sua thanh cong");
        //        hienthi();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void BtnDeleteToGiac_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from Vuan where SoTTVuan='" + ID + "'", con);
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddVuAn_Click_1(object sender, EventArgs e)
        {
            if (txtSoTT.Text == "" || txtTenTamGiu.Text == "" || QDTamGiu.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "" || txtLyDoTamGiu.Text == "" || TxtGhiChu.Text == "")
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
                    cmd = new SqlCommand("insert into Vuan (SoTTVuan,QDtamgiu,Tennguoitamgiu,QDgiahantamgiulan1,QDgiahantamgiulan2,Lydotamgiu,Ghichu,NgayKhoiTo) values( '" + txtSoTT.Text + "','" + QDTamGiu.Text + "','" + txtTenTamGiu.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + txtLyDoTamGiu.Text + "','" + TxtGhiChu.Text + "','"+ dateTimePicker3.Text +"') ", con);
                   

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

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSoTT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            QDTamGiu.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenTamGiu.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtGhiChu.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtLyDoTamGiu.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();




            //rbtnMale.Checked = true;
            //rbtnFeMale.Checked = false;
            //if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()=="Female")
            //{
            //    rbtnMale.Checked = false;
            //    rbtnFeMale.Checked = true;
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                BiCan test = new BiCan();
                //MemoryStream stream = new MemoryStream();
                //pictureBox7.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] pic = stream.ToArray();
                //cmd.Parameters.AddWithValue("@Pic", pic);
                con.Open();
                cmd = new SqlCommand("update Vuan set QDtamgiu='" + QDTamGiu.Text + "',Tennguoitamgiu='" + txtTenTamGiu.Text + "',QDgiahantamgiulan1='" + dateTimePicker1.Text + "',QDgiahantamgiulan2='" + dateTimePicker2.Text + "',Lydotamgiu='" + txtLyDoTamGiu.Text + "',Ghichu='" + TxtGhiChu.Text + "',NgayKhoiTo='" +dateTimePicker3.Text +"' where SoTTVuan='" + ID + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new SqlCommand("update GiaiDoan set GIAIDOAN='" + "GD2" + "'  where IDVUAN='" + ID + "' ", con);
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
                cmd = new SqlCommand("delete from Vuan where SoTTVuan='" + ID + "'", con);
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
        public void hienthi()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Vuan", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home clicktogiac = new Home();
            clicktogiac.Show();
            this.Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            BiCan clicktogiac = new BiCan();
            clicktogiac.Show();
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            TGXetXu clicktogiac = new TGXetXu();
            clicktogiac.Show();
            this.Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

            SearchTT clicktogiac = new SearchTT();
            clicktogiac.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
