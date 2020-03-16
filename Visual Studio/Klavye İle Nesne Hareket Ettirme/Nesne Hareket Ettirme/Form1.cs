using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Hareket_Ettirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* Klavye ile kontrol etme */

        private void klavye_yakala(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                pictureBox1.Top -= 10;
            }
            if (e.KeyCode == Keys.S)
            {
                pictureBox1.Top += 10;
            }
            if (e.KeyCode == Keys.A)
            {
                pictureBox1.Left -= 10;
            }
            if (e.KeyCode == Keys.D)
            {
                pictureBox1.Left += 10;
            }
        }

        /* Klavye ile kontrol etme kapat */
    }
}
