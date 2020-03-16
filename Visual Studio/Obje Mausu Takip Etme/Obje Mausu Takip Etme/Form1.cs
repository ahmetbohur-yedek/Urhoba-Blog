using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obje_Mausu_Takip_Etme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Fare konumunu alıyoruz
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            /* 1. Yöntem Objenin direkt olarak gitmesini sağlamak */

            // objenin konumunu direkt olarak farenin konumuna eşitliyoruz.
            pictureBox1.Location = new Point(x, y);

            /* Objenin direkt olarak gitmesini sağlamak */

            /* 2. Yöntem Objenin yavaş yavaş gitmesini sağlamak */

            // Objenin geçerli konumunu alıyoruz
            int px = pictureBox1.Location.X;
            int py = pictureBox1.Location.Y;

            // Objenin geçerli konumuna göre yavaş yavaş eklemeler ile fareye doğru ilerlemesini sağlıyoruz

            if(x > px)
            {
                
                pictureBox1.Left += 1;
            }
            else if(x < px)
            {
              
                pictureBox1.Left -= 1;
            }
            else
            {

            }

            if(y > py)
            {
           
                pictureBox1.Top += 1;
            }
            else if(y <py)
            {
               
                pictureBox1.Top -= 1;
            }
            else
            {

            }

            /* Objenin yavaş yavaş gitmesini sağlamak */
        }
    }
}
