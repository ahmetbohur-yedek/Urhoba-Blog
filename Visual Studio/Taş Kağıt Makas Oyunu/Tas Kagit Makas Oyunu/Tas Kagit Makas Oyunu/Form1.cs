using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas_Kagit_Makas_Oyunu
{
    public partial class Form1 : Form
    {
        public int single_score = 0;
        public Form1()
        {
            this.KeyPreview = true;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void multy_pb_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = true;
        }

        public void single_tas_kagit_makas(int secim_user)
        {
            Random rand = new Random();
            int secim_pc = rand.Next(0, 2 + 1);

            string[] rsp = { "Taş", "Kağıt", "Makas" };

            // Taş = 0 Kağıt = 1 Makas = 2
            if (secim_user == 0 && secim_pc == 0 || secim_user == 1 && secim_pc == 1 || secim_user == 2 && secim_pc == 2)
            {
                tek_oyuncu_bilgi.Text = "Berabere kaldınız" + "\n Bilgisayar : " + rsp[secim_pc] + "\n Sen : " + rsp[secim_user];
            }
            else if (secim_user == 0 && secim_pc == 2 || secim_user == 1 && secim_pc == 0 || secim_user == 2 && secim_pc == 1)
            {
                tek_oyuncu_bilgi.Text = "Kazandınız" + "\n Bilgisayar : " + rsp[secim_pc] + "\n Sen : " + rsp[secim_user];
                single_score++;
                tek_oyuncu_puan.Text = "Puan : " + single_score.ToString();
            }
            else
            {
                tek_oyuncu_bilgi.Text = "Kaybettiniz" + "\n Bilgisayar : " + rsp[secim_pc] + "\n Sen : " + rsp[secim_user];
                single_score--;
                tek_oyuncu_puan.Text = "Puan : " + single_score.ToString();
            }

        }

        public void  multiplayer_tas_kagit_makas(int user1, int user2)
        {           

            string[] rsp = { "Taş", "Kağıt", "Makas" };

            // Taş = 0 Kağıt = 1 Makas = 2
            if (user1 == 0 && user2 == 0 || user1 == 1 && user2 == 1 || user1 == 2 && user2 == 2)
            {
                ark_bilgilendirme.Text = "Berabere kaldınız" + "\n 1. Oyuncu : " + rsp[user1] + "\n 2. Oyuncu : " + rsp[user2];
            }
            else if (user1 == 0 && user2 == 2 || user1 == 1 && user2 == 0 || user1 == 2 && user2 == 1)
            {
                ark_bilgilendirme.Text = "1. Oyuncu Kazandınız 2. Oyuncu Kaybettiniz" + "\n 1. Oyuncu : " + rsp[user1] + "\n 2. Oyuncu : " + rsp[user2];

                ark_puan.Text = "Puan : " + single_score.ToString();
            }
            else
            {
                ark_bilgilendirme.Text = "1. Oyuncu Kaybettiniz 2. Oyuncu Kazandınız" + "\n 1. Oyuncu : " + rsp[user1] + "\n 2. Oyuncu : " + rsp[user2];

                ark_puan.Text = "Puan : " + single_score.ToString();
            }

        }


        private void tas_Click(object sender, EventArgs e)
        {
            single_tas_kagit_makas(0);
            
        }

        private void kagit_Click(object sender, EventArgs e)
        {
            single_tas_kagit_makas(1);
        }

        private void makas_Click(object sender, EventArgs e)
        {
            single_tas_kagit_makas(2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        // Key Yakalama
        public int oyuncu_1 = -1, oyuncu_2 = -1;
        private void Key_Press(object sender, KeyPressEventArgs e)
         {
           
            if(e.KeyChar.ToString() == "a")
            {
                oyuncu_1 = 0;
            }
            else if(e.KeyChar.ToString() == "s")
            {
                oyuncu_1 = 1;
            }
            else if (e.KeyChar.ToString() == "d")
            {
                oyuncu_1 = 2;
            }

            if (e.KeyChar.ToString() == "1")
            {
                oyuncu_2 = 0;
            }
            else if (e.KeyChar.ToString() == "2")
            {
                oyuncu_2 = 1;
            }
            else if (e.KeyChar.ToString() == "3")
            {
                oyuncu_2 = 2;
            }


            if (oyuncu_1 != -1 && oyuncu_2 != -1)
            {
                multiplayer_tas_kagit_makas(oyuncu_1, oyuncu_2);
                oyuncu_1 = -1;
                oyuncu_2 = -1;
            }

        }

        private void ark_puan_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Key_Press_Up(object sender, KeyEventArgs e)
        {
           
        }

    }
}
