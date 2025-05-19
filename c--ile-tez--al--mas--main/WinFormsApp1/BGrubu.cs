using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class BGrubu : Form
    {
        public string sayi2;


        public BGrubu()
        {
            InitializeComponent();
        }
        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Enter tuşunun varsayılan davranışını engelle
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CGrubu form5 = new CGrubu(); // Form2'nin bir örneğini oluştur
            form5.sayi1 = label10.Text;
            label5.Text = sayi2;
            form5.sayi2 = label5.Text;
            form5.Show(); // Form2'yi göster
            this.Hide();  // İsteğe bağlı: Form1'i gizle (kapatmaz)
            string deger3 = label10.Text; // Form1'deki label değeri

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AGrubu aGrubu = new AGrubu();
            aGrubu.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Önce boş alan kontrolü:
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 ||
                comboBox3.SelectedIndex == -1 ||
                comboBox4.SelectedIndex == -1 ||
                comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi");
                return; // Skor hesaplamasına geçme
            }

            // Skor hesaplaması başlıyor
            try
            {
                // 3B REBA skor tablosu: [boyun, bacak, govde]
                int[,,] rebaB = new int[2, 6, 3]
                {
            // Alt Kol 1
            {
                { 1,2,2}, { 1,2,3}, { 3,4,5}, {4,5,5}, {6,7,8}, {7,8,8}
            },
            // Alt Kol 2
            {
                { 1,2,3}, {2,3,4}, { 4, 5, 5 }, {5,6,7}, {7,8,8}, { 8,9,9 }
            }
                };

                int altkol = int.Parse(textBox1.Text);   // 1–3
                int ustkol = int.Parse(textBox2.Text);   // 1–6
                int bilek = int.Parse(textBox3.Text);   // 1–2

                int altkolIndex = altkol - 1;
                int ustkolIndex = ustkol - 1;
                int bilekIndex = bilek - 1;

                if (altkolIndex < 0 || altkolIndex > 1 || ustkolIndex < 0 || ustkolIndex > 3 || bilekIndex < 0 || bilekIndex > 1)
                {
                    MessageBox.Show("Lütfen geçerli aralıkta değerler giriniz:\nAlt Kol: 1–2\nÜst Kol: 1–4\nBilek: 1–2");
                    return;
                }

                int skor = rebaB[altkolIndex, ustkolIndex, bilekIndex];

                if (comboBox1.SelectedItem.ToString() == "Evet") skor += 1;
                if (comboBox2.SelectedItem.ToString() == "Evet") skor += 1;
                if (comboBox3.SelectedItem.ToString() == "Evet") skor -= 1;
                if (comboBox4.SelectedItem.ToString() == "Evet") skor += 1;

                if (comboBox5.SelectedItem.ToString() == "Orta") skor += 1;
                else if (comboBox5.SelectedItem.ToString() == "Zayıf") skor += 2;
                else if (comboBox5.SelectedItem.ToString() == "İyi") skor += 0;
                else if (comboBox5.SelectedItem.ToString() == "Uygun Değil") skor += 3;


                label4.Text = "B Grubu Skoru: " + skor.ToString();
                label10.Text = skor.ToString();

                button1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli sayısal değerler giriniz.");
            }
        }
    }
}
   

