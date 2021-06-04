using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmtpMail
{
    public partial class FrmGmail : Form
    {
        void epostaGonder(String kime, String konu, String icerik)
        {
            String kimden = "ornek@gmail.com";
            MailMessage message = new MailMessage(kimden, kime);
            message.Subject = konu;
            message.Body = icerik;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            NetworkCredential epostabilgileri = new NetworkCredential("ornek@gmail.com", "hesap-parolası");
            client.Credentials = epostabilgileri;
            client.EnableSsl = true;
            
            try
            {
                client.SendAsync(message,null);
                MessageBox.Show("Başarılı şekilde göderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public FrmGmail()
        {
            InitializeComponent();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            epostaGonder(TxtKime.Text, TxtKonu.Text, RchIcerik.Text);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtKime.ResetText();
            TxtKonu.ResetText();
            RchIcerik.Clear();
        }
    }
}
