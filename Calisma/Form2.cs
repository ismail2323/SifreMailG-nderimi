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
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
namespace Calisma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L96504Q\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Giris where Mail=@p1 and KullaniciAd=@p2 ", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtMail.Text);
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm = new Form1() ;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Sifre");
            }
            baglanti.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Sql baglan = new Sql();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Giris Where Kullaniciad = '" + TxtAd.Text.ToString() + "'and Mail = '" + TxtMail.Text.ToString() + "'", baglan.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (baglan.baglanti().State == ConnectionState.Closed)
                    {
                        baglan.baglanti().Open();
                    }
                        SmtpClient smtpserver = new SmtpClient();
                        MailMessage mail = new MailMessage();
                        String tarih = DateTime.Now.ToLongDateString();
                        String mailadresim = ("odevmail230@gmail.com");
                        String sifre = "bzvlzkiuhqgpuhes";
                        String smptserver = "smtp.gmail.com";
                        String kime = (oku["Mail"].ToString());
                        String konu = ("Şifre Hatırlatma Mail'i");
                        String yaz = (tarih + " Tarihli istediğiniz şifre hatırlatma isteğiniz üzerine bu Mail gönderilmiştir" + "\n" + "Parolanız:" + oku["Sifre"].ToString());
                        smtpserver.Credentials = new NetworkCredential(mailadresim, sifre);
                        smtpserver.Port = 587;
                        smtpserver.Host = smptserver;
                        smtpserver.EnableSsl = true;
                        mail.From = new MailAddress(mailadresim);
                        mail.To.Add(kime);
                        mail.Subject = konu;
                        mail.Body = yaz;
                        smtpserver.Send(mail);
                        DialogResult bilgi = new DialogResult();
                        bilgi = MessageBox.Show("Şifreniz Mail adresinize gönderildi");
                        this.Hide();
                        
                    
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Hatalı Giriş", Hata.Message);
                }
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
