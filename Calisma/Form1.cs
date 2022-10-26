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


namespace Calisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L96504Q\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
         
        void temizle ()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            groupBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p4,@p5,@p6,@p7)",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);
            komut.Parameters.AddWithValue("@p7", label1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "True";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "False";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where PerAd=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",textBox2.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi"); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where PerSoyad=@a2", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label1.Text);
            komutguncelle.Parameters.AddWithValue("@a6", textBox4.Text);
            komutguncelle.ExecuteNonQuery();              
            baglanti.Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
}
