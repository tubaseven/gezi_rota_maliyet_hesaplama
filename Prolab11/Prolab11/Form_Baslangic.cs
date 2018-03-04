using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab11
{
    public partial class Form_Baslangic : Form
    {
        public Form_Baslangic()
        {
            InitializeComponent();
        }

        private void button_onayla_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            timer1.Start();

            DATA.varis_sehri_plaka_kodu = comboBox_varis.SelectedIndex;
            DATA.baslangic_sehri_plaka_kodu = comboBox_baslangic.SelectedIndex;
            DATA.kisi_sayisi =(int)numericUpDown1.Value;
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac == 4)
            {
                timer1.Stop();
                this.Hide();
                Form_Chart chrt = new Form_Chart();
                chrt.Show();

                Islemler islemler = new Islemler();
                islemler.Coz();
            }

            sayac++;
        }

        private void button_gozat_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

                DATA.verilenDosyalarinKlasoru = textBox1.Text;
                DATA.VerilenDosyalariYukle();

                for (int i = 0; i < DATA.dugumler.Length; i++)
                {
                    string sehirIsmi=DATA.dugumler[i].isim;
                    comboBox_baslangic.Items.Add(sehirIsmi);
                    comboBox_varis.Items.Add(sehirIsmi);
                }

                groupBox1.Enabled = true;
            }
        }
    }
}
