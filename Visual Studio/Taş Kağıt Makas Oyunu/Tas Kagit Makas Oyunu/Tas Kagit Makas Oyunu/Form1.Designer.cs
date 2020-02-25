namespace Tas_Kagit_Makas_Oyunu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.multy_pb = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tek_oyuncu_bilgi = new System.Windows.Forms.Label();
            this.tek_oyuncu_puan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.makas = new System.Windows.Forms.Button();
            this.kagit = new System.Windows.Forms.Button();
            this.tas = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ark_bilgilendirme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ark_puan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.multy_pb);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 300);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(119, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "1 Oyuncu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // multy_pb
            // 
            this.multy_pb.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multy_pb.Location = new System.Drawing.Point(119, 115);
            this.multy_pb.Name = "multy_pb";
            this.multy_pb.Size = new System.Drawing.Size(200, 50);
            this.multy_pb.TabIndex = 2;
            this.multy_pb.Text = "2 Oyuncu";
            this.multy_pb.UseVisualStyleBackColor = true;
            this.multy_pb.Click += new System.EventHandler(this.multy_pb_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tek_oyuncu_bilgi);
            this.panel2.Controls.Add(this.tek_oyuncu_puan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.makas);
            this.panel2.Controls.Add(this.kagit);
            this.panel2.Controls.Add(this.tas);
            this.panel2.Location = new System.Drawing.Point(15, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 300);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tek_oyuncu_bilgi
            // 
            this.tek_oyuncu_bilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tek_oyuncu_bilgi.AutoSize = true;
            this.tek_oyuncu_bilgi.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tek_oyuncu_bilgi.Location = new System.Drawing.Point(4, 67);
            this.tek_oyuncu_bilgi.Name = "tek_oyuncu_bilgi";
            this.tek_oyuncu_bilgi.Size = new System.Drawing.Size(0, 27);
            this.tek_oyuncu_bilgi.TabIndex = 9;
            // 
            // tek_oyuncu_puan
            // 
            this.tek_oyuncu_puan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tek_oyuncu_puan.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tek_oyuncu_puan.Location = new System.Drawing.Point(3, 196);
            this.tek_oyuncu_puan.Name = "tek_oyuncu_puan";
            this.tek_oyuncu_puan.Size = new System.Drawing.Size(370, 30);
            this.tek_oyuncu_puan.TabIndex = 8;
            this.tek_oyuncu_puan.Text = "Puan : 0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bilgisayara Karşı Oyna";
            // 
            // makas
            // 
            this.makas.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makas.Location = new System.Drawing.Point(281, 238);
            this.makas.Name = "makas";
            this.makas.Size = new System.Drawing.Size(130, 50);
            this.makas.TabIndex = 6;
            this.makas.Text = "Makas";
            this.makas.UseVisualStyleBackColor = true;
            this.makas.Click += new System.EventHandler(this.makas_Click);
            // 
            // kagit
            // 
            this.kagit.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kagit.Location = new System.Drawing.Point(145, 238);
            this.kagit.Name = "kagit";
            this.kagit.Size = new System.Drawing.Size(130, 50);
            this.kagit.TabIndex = 5;
            this.kagit.Text = "Kağıt";
            this.kagit.UseVisualStyleBackColor = true;
            this.kagit.Click += new System.EventHandler(this.kagit_Click);
            this.kagit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Press_Up);
            this.kagit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_Press);
            this.kagit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key_Press_Up);
            // 
            // tas
            // 
            this.tas.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tas.Location = new System.Drawing.Point(9, 238);
            this.tas.Name = "tas";
            this.tas.Size = new System.Drawing.Size(130, 50);
            this.tas.TabIndex = 4;
            this.tas.Text = "Taş";
            this.tas.UseVisualStyleBackColor = true;
            this.tas.Click += new System.EventHandler(this.tas_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ark_bilgilendirme);
            this.panel3.Controls.Add(this.ark_puan);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(13, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 300);
            this.panel3.TabIndex = 10;
            this.panel3.Visible = false;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Arkadaşına Karşı Oyna";
            // 
            // ark_bilgilendirme
            // 
            this.ark_bilgilendirme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ark_bilgilendirme.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ark_bilgilendirme.Location = new System.Drawing.Point(3, 105);
            this.ark_bilgilendirme.Name = "ark_bilgilendirme";
            this.ark_bilgilendirme.Size = new System.Drawing.Size(418, 121);
            this.ark_bilgilendirme.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 75);
            this.label2.TabIndex = 10;
            this.label2.Text = "1. Oyuncu asd 2. Oyuncu 123 Tuşları ile oynuyor ve tuşlar taş kağıt makas olarak " +
    "sıralanıyor";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ark_puan
            // 
            this.ark_puan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ark_puan.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ark_puan.Location = new System.Drawing.Point(3, 270);
            this.ark_puan.Name = "ark_puan";
            this.ark_puan.Size = new System.Drawing.Size(374, 30);
            this.ark_puan.TabIndex = 8;
            this.ark_puan.Text = "Puan : 0";
            this.ark_puan.Visible = false;
            this.ark_puan.Click += new System.EventHandler(this.ark_puan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ahmet Bohur";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(480, 400);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "Form1";
            this.Text = "Taş Kağıt Makas Oyunu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Press_Up);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_Press);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key_Press_Up);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button multy_pb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label tek_oyuncu_bilgi;
        private System.Windows.Forms.Label tek_oyuncu_puan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button makas;
        private System.Windows.Forms.Button kagit;
        private System.Windows.Forms.Button tas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label ark_bilgilendirme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ark_puan;
        private System.Windows.Forms.Label label3;
    }
}

