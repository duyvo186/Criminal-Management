using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp5
{
    public partial class FormForGot : Form
    {
        string randomCode;
        public static string to;

        public FormForGot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "huuduy8989@gmail.com";
            pass = "Dgl1806##";
            messageBody = "your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Gửi Thành Công" );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtverìy.Text).ToString())
            {
                to = txtEmail.Text;
                txtPasverìy rp = new txtPasverìy();
                
                rp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai Mã Code");
            }
        }
    }
}
