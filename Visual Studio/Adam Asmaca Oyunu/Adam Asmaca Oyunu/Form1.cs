/*
Ahmet Bohur // 19.02.2020
Adam Asmaca Oyunu
  
  */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam_Asmaca_Oyunu
{
    public partial class Form1 : Form
    {
        public string bulunacak_kelime;        
        public string[] bulunan_harfler;
        public int can;
        public double resim_parcalari = 0;
        
     
        public Form1()
        {
            
            InitializeComponent();
            // Başlangıç anında formun boyutunun küçük olmasını sağlama kısmı
            this.Size = new Size(185, 100);
            this.MaximumSize = new Size(185, 100);
            this.MinimumSize = new Size(185, 100);
        }
        // Kelime seçme işlemi
        string Bulunacak_Kelime()
        {
            Random rand = new Random();
           
            string[] kelimeler = new string[10];
            kelimeler[0] = "Sevgi";
            kelimeler[1] = "Aşk";
            kelimeler[2] = "Araba";
            kelimeler[3] = "İhanet";
            kelimeler[4] = "Emek";
            kelimeler[5] = "Bilgisayar";
            kelimeler[6] = "Yazılım";
            kelimeler[7] = "Arkadaşlık";
            kelimeler[8] = "Dostluk";
            kelimeler[9] = "Öğretmen";
            int random_sayi = rand.Next(0, kelimeler.Length);
            return kelimeler[random_sayi];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Panel 1 kapat
            panel1.Visible = false;
           
            // Bulunacak kelimeyi değişkene atama ve harfleri büyütme.
            bulunacak_kelime = Bulunacak_Kelime().ToUpper();
            can = bulunacak_kelime.Length;
            label4.Text = can.ToString() + " deneme hakkınız kaldı";
           
          

            // Bulunan harfleri göstermek için olan char dizisi
            bulunan_harfler = new string[bulunacak_kelime.Length];
            label3.Text = "";
            for (int i = 0; i < bulunacak_kelime.Length; i++)
            {              
                bulunan_harfler[i] = "_ "; // İlk harfler bulunmadığı için _ koyuyoruz. 
                label3.Text += bulunan_harfler[i].ToString();
            }

            // Bulunacak kelime ile ilgili bilgi verme
            Label1.Text = "Bulmanız gereken kelime " + bulunacak_kelime.Length.ToString() + " Harflidir.";

            // Panel2 yi açma ve formun boyutunu büyütme.
            panel2.Visible = true;
            Form1.ActiveForm.Size = new Size(900,500);
            Form1.ActiveForm.MaximumSize = new Size(900, 500);
            Form1.ActiveForm.MinimumSize = new Size(900, 500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Resimlerin birbirinin önüne geçip görüntüyü bozmasını engellemek için transparan yapıyoruz arkaplan rengini
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool dogru_bildimi = false;

                // Kelime tahminini kontrol ediyoruz
                string girilen_kelime = textBox1.Text.ToUpper();


                if (string.IsNullOrEmpty(girilen_kelime) && string.IsNullOrWhiteSpace(girilen_kelime))
                {
                }
                else
                {
                    if (girilen_kelime == bulunacak_kelime)
                    {
                        // Doğru ise ilk olarak label 3 ü temizliyoruz ve sonra doğru kelimenin harfleri arasına boşluk koyarak yazıyoruz.
                        label3.Text = "";
                        for (int i = 0; i < bulunacak_kelime.Length; i++)
                        {
                            label3.Text += girilen_kelime[i] + " ";
                        }
                        Oyunu_Kazandin();
                    }
                    else
                    {
                        label3.Text = "";
                        // Girilen kelime yanlış ise girilen kelimenin ilk harfini alarak harf elemesinden geçiriyoruz.
                        for (int i = 0; i < bulunacak_kelime.Length; i++)
                        {
                            if (girilen_kelime[0] == bulunacak_kelime[i])
                            {
                                bulunan_harfler[i] = girilen_kelime[0] + " ";
                                dogru_bildimi = true;
                            }
                        }


                        // Girilen harflerin hepsi doğru ise cevap ta doğrdudur bunu yaptık.
                        if (bulunan_harfler.Contains("_ ") == false)
                        {
                            Oyunu_Kazandin();
                        }
                        Dogru_Bildimi(dogru_bildimi);


                        for (int b = 0; b < bulunacak_kelime.Length; b++)
                        {
                            label3.Text += bulunan_harfler[b];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Şu anda sistemde bir hata var.");
            }
        }
        void Dogru_Bildimi(bool dogru_bildimi)
        {
            if (!dogru_bildimi)
            {
                if (can > 0)
                {
                    // Harf de yanlış ise can değerini azaltıyoruz
                    can--;
                    // Kaç deneme hakkı kaldığını söylüyoruz
                    label4.Text = can.ToString() + " deneme hakkınız kaldı";
                    // Görseller için basit bir hesaplama yapıyoruz kaç adımda resmin tamamının gösterileceği
                    resim_parcalari += (8.0 / bulunacak_kelime.Length);
                    // Hesaplama sonucunda resimleri göteriyoruz.
                    Resim_Parcalarini_Goster(resim_parcalari);
                    if (can == 0)
                    {
                    
                        // Can 0 olduğu ve oyun bittiği için artık butonlara tıklanmasını engelliyoruz.
                        textBox1.Enabled = false;
                        button2.Enabled = false;

                        button3.Visible = true;
                    }

                }
            }
        }
        void Oyunu_Kazandin()
        {
            label2.Text = "Cevap doğru kazandınız.";
            label4.Text = "Cevap doğru kazandınız";

            // oyun bittiği için artık butonlara tıklanmasını engelliyoruz.
            textBox1.Enabled = false;
            button2.Enabled = false;

            button3.Visible = true;
        }

        void Resim_Parcalarini_Goster(double sayi)
        {
            if (sayi >= 1)
            {
                pictureBox1.Visible = true;
                if (sayi >= 2)
                {
                    pictureBox2.Visible = true;
                    if (sayi >= 3)
                    {
                        pictureBox3.Visible = true;
                        if (sayi >= 4)
                        {
                            pictureBox4.Visible = true;
                            if (sayi >= 5)
                            {
                                pictureBox5.Visible = true;
                                if (sayi >= 6)
                                {
                                    pictureBox6.Visible = true;
                                    if (sayi >= 7)
                                    {
                                        pictureBox7.Visible = true;
                                        if (sayi >= 8)
                                        {
                                            pictureBox8.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

     

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Uygulamayı yeniden başlatıyoruz.
            Application.Restart();
        }
    }
}
