namespace Prolab11
{
    partial class Form_Chart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Chart));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_sonuc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_sabitUCret_Kaydet = new System.Windows.Forms.Button();
            this.button_sabitUcret_Ciz = new System.Windows.Forms.Button();
            this.comboBox_sabitUCret = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_degiskenUcret_Kaydet = new System.Windows.Forms.Button();
            this.button_degiskenUcret_Ciz = new System.Windows.Forms.Button();
            this.comboBox_degiskenUCret = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 710);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_sonuc
            // 
            this.textBox_sonuc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_sonuc.Location = new System.Drawing.Point(0, 707);
            this.textBox_sonuc.Multiline = true;
            this.textBox_sonuc.Name = "textBox_sonuc";
            this.textBox_sonuc.Size = new System.Drawing.Size(1016, 42);
            this.textBox_sonuc.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_sabitUCret_Kaydet);
            this.groupBox1.Controls.Add(this.button_sabitUcret_Ciz);
            this.groupBox1.Controls.Add(this.comboBox_sabitUCret);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sabit Ücret Max Kar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "YOLCU SAYISI :";
            // 
            // button_sabitUCret_Kaydet
            // 
            this.button_sabitUCret_Kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_sabitUCret_Kaydet.Location = new System.Drawing.Point(347, 17);
            this.button_sabitUCret_Kaydet.Name = "button_sabitUCret_Kaydet";
            this.button_sabitUCret_Kaydet.Size = new System.Drawing.Size(91, 26);
            this.button_sabitUCret_Kaydet.TabIndex = 2;
            this.button_sabitUCret_Kaydet.Text = "KAYDET";
            this.button_sabitUCret_Kaydet.UseVisualStyleBackColor = true;
            this.button_sabitUCret_Kaydet.Click += new System.EventHandler(this.button_sabitUCret_Kaydet_Click);
            // 
            // button_sabitUcret_Ciz
            // 
            this.button_sabitUcret_Ciz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_sabitUcret_Ciz.Location = new System.Drawing.Point(247, 17);
            this.button_sabitUcret_Ciz.Name = "button_sabitUcret_Ciz";
            this.button_sabitUcret_Ciz.Size = new System.Drawing.Size(94, 26);
            this.button_sabitUcret_Ciz.TabIndex = 1;
            this.button_sabitUcret_Ciz.Text = "ÇİZ";
            this.button_sabitUcret_Ciz.UseVisualStyleBackColor = true;
            this.button_sabitUcret_Ciz.Click += new System.EventHandler(this.button_sabitUcret_Ciz_Click);
            // 
            // comboBox_sabitUCret
            // 
            this.comboBox_sabitUCret.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_sabitUCret.FormattingEnabled = true;
            this.comboBox_sabitUCret.Location = new System.Drawing.Point(125, 19);
            this.comboBox_sabitUCret.Name = "comboBox_sabitUCret";
            this.comboBox_sabitUCret.Size = new System.Drawing.Size(116, 24);
            this.comboBox_sabitUCret.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_degiskenUcret_Kaydet);
            this.groupBox2.Controls.Add(this.button_degiskenUcret_Ciz);
            this.groupBox2.Controls.Add(this.comboBox_degiskenUCret);
            this.groupBox2.Location = new System.Drawing.Point(471, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 60);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Değişken Ücret %50 Kar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "YOLCU SAYISI :";
            // 
            // button_degiskenUcret_Kaydet
            // 
            this.button_degiskenUcret_Kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_degiskenUcret_Kaydet.Location = new System.Drawing.Point(347, 17);
            this.button_degiskenUcret_Kaydet.Name = "button_degiskenUcret_Kaydet";
            this.button_degiskenUcret_Kaydet.Size = new System.Drawing.Size(91, 26);
            this.button_degiskenUcret_Kaydet.TabIndex = 2;
            this.button_degiskenUcret_Kaydet.Text = "KAYDET";
            this.button_degiskenUcret_Kaydet.UseVisualStyleBackColor = true;
            this.button_degiskenUcret_Kaydet.Click += new System.EventHandler(this.button_degiskenUcret_Kaydet_Click);
            // 
            // button_degiskenUcret_Ciz
            // 
            this.button_degiskenUcret_Ciz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_degiskenUcret_Ciz.Location = new System.Drawing.Point(247, 17);
            this.button_degiskenUcret_Ciz.Name = "button_degiskenUcret_Ciz";
            this.button_degiskenUcret_Ciz.Size = new System.Drawing.Size(94, 26);
            this.button_degiskenUcret_Ciz.TabIndex = 1;
            this.button_degiskenUcret_Ciz.Text = "ÇİZ";
            this.button_degiskenUcret_Ciz.UseVisualStyleBackColor = true;
            this.button_degiskenUcret_Ciz.Click += new System.EventHandler(this.button_degiskenUcret_Ciz_Click);
            // 
            // comboBox_degiskenUCret
            // 
            this.comboBox_degiskenUCret.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_degiskenUCret.FormattingEnabled = true;
            this.comboBox_degiskenUCret.Location = new System.Drawing.Point(121, 19);
            this.comboBox_degiskenUCret.Name = "comboBox_degiskenUCret";
            this.comboBox_degiskenUCret.Size = new System.Drawing.Size(120, 24);
            this.comboBox_degiskenUCret.TabIndex = 0;
            // 
            // Form_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_sonuc);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "zel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Chart_FormClosing);
            this.Load += new System.EventHandler(this.Form_Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_sonuc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_sabitUCret_Kaydet;
        private System.Windows.Forms.Button button_sabitUcret_Ciz;
        private System.Windows.Forms.ComboBox comboBox_sabitUCret;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_degiskenUcret_Kaydet;
        private System.Windows.Forms.Button button_degiskenUcret_Ciz;
        private System.Windows.Forms.ComboBox comboBox_degiskenUCret;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}