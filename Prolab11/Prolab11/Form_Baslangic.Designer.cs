namespace Prolab11
{
    partial class Form_Baslangic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_onayla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_varis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_baslangic = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_dosyaYolu = new System.Windows.Forms.TextBox();
            this.button_gozat = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_onayla);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_varis);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_baslangic);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(9, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(475, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button_onayla
            // 
            this.button_onayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_onayla.Location = new System.Drawing.Point(24, 149);
            this.button_onayla.Margin = new System.Windows.Forms.Padding(2);
            this.button_onayla.Name = "button_onayla";
            this.button_onayla.Size = new System.Drawing.Size(408, 40);
            this.button_onayla.TabIndex = 4;
            this.button_onayla.Text = "ONAYLA";
            this.button_onayla.UseVisualStyleBackColor = true;
            this.button_onayla.Click += new System.EventHandler(this.button_onayla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(20, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "VARIŞ ŞEHRİ";
            // 
            // comboBox_varis
            // 
            this.comboBox_varis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_varis.FormattingEnabled = true;
            this.comboBox_varis.Location = new System.Drawing.Point(198, 84);
            this.comboBox_varis.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_varis.Name = "comboBox_varis";
            this.comboBox_varis.Size = new System.Drawing.Size(235, 28);
            this.comboBox_varis.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "BAŞLANGIÇ ŞEHRİ";
            // 
            // comboBox_baslangic
            // 
            this.comboBox_baslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_baslangic.FormattingEnabled = true;
            this.comboBox_baslangic.Location = new System.Drawing.Point(198, 20);
            this.comboBox_baslangic.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_baslangic.Name = "comboBox_baslangic";
            this.comboBox_baslangic.Size = new System.Drawing.Size(235, 28);
            this.comboBox_baslangic.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(9, 326);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 39);
            this.panel1.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 11);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(452, 19);
            this.progressBar1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "DOSYA KLASÖRÜ";
            // 
            // textBox_dosyaYolu
            // 
            this.textBox_dosyaYolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_dosyaYolu.Location = new System.Drawing.Point(198, 25);
            this.textBox_dosyaYolu.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_dosyaYolu.Name = "textBox_dosyaYolu";
            this.textBox_dosyaYolu.Size = new System.Drawing.Size(179, 26);
            this.textBox_dosyaYolu.TabIndex = 10;
            this.textBox_dosyaYolu.Text = "C:\\Users\\seven\\Desktop\\prolab11_dosyalar";
            // 
            // button_gozat
            // 
            this.button_gozat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_gozat.Location = new System.Drawing.Point(376, 25);
            this.button_gozat.Margin = new System.Windows.Forms.Padding(2);
            this.button_gozat.Name = "button_gozat";
            this.button_gozat.Size = new System.Drawing.Size(56, 24);
            this.button_gozat.TabIndex = 11;
            this.button_gozat.Text = "GÖZAT";
            this.button_gozat.UseVisualStyleBackColor = true;
            this.button_gozat.Click += new System.EventHandler(this.button_gozat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_gozat);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_dosyaYolu);
            this.panel2.Location = new System.Drawing.Point(9, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 81);
            this.panel2.TabIndex = 12;
            // 
            // Form_Baslangic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Baslangic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEÇİM İŞLEMİ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Baslangic_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_baslangic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_varis;
        private System.Windows.Forms.Button button_onayla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_gozat;
        private System.Windows.Forms.TextBox textBox_dosyaYolu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel2;
    }
}