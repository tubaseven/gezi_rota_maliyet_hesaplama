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

        // sadece arayüzde sehir secmek icin kullanıldı.
        DugumYapisi dugumYapisi = new DugumYapisi();

        private void button_gozat_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_dosyaYolu.Text = folderBrowserDialog1.SelectedPath;

                DATA.verilenDosyalarinKlasoru = textBox_dosyaYolu.Text;

                Islemler.VerilenDosyalardanGrafOlustur(dugumYapisi);

                for (int i = 0; i < dugumYapisi.dugumler.Length; i++)
                {
                    string sehirIsmi = dugumYapisi.dugumler[i].isim;
                    comboBox_baslangic.Items.Add(sehirIsmi);
                    comboBox_varis.Items.Add(sehirIsmi);
                }

                groupBox1.Enabled = true;
            }
        }


        private void button_onayla_Click(object sender, EventArgs e)
        {
            // il seçimleri yapılmadan işleme izin verilmez :)
            if (comboBox_baslangic.SelectedIndex == -1 || comboBox_varis.SelectedIndex == -1)
                return;

            groupBox1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;

            DATA.varis_sehri_plaka_kodu = comboBox_varis.SelectedIndex;
            DATA.baslangic_sehri_plaka_kodu = comboBox_baslangic.SelectedIndex;

            // graflar oluşturulup, yolcu sayısına göre en kısa yol bulunuyor
            Coz();

            // harita açılıyor:
            Form_Chart formChart = new Form_Chart();
            formChart.Show();
            this.Hide();
        }


        public void Coz()
        {
            // sabit ücret işlemleri için DugumYapilari oluşturuluyor:
            // 5,6,7,...,49,50 adet yolcu için ayrı ayrı graf hazırlanıyor:
            DATA.dugumYapilari_sabit_ucret_max_kar = new DugumYapisi[46];
            for (int i = 5; i <= 50; i++)
            {
                DATA.dugumYapilari_sabit_ucret_max_kar[i - 5] = new DugumYapisi()
                {
                    dugumler = new Dugum[81],
                    yolcuSayisi = i,
                    kisiBasiPara = 20
                };
            }
            // sabit ücret çözüm işlemleri:
            for (int i = 0; i < DATA.dugumYapilari_sabit_ucret_max_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_sabit_ucret_max_kar[i];

                Islemler islemler = new Islemler();
                islemler.Coz(dugumYapisi);
            }
            // sabit ücret kar hesaplama
            for (int i = 0; i < DATA.dugumYapilari_sabit_ucret_max_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_sabit_ucret_max_kar[i];

                dugumYapisi.kar = dugumYapisi.yolcuSayisi * dugumYapisi.kisiBasiPara - dugumYapisi.yolunZeplineMaliyeti;
            }

            DATA.dugumYapilari_sabit_ucret_max_kar = DATA.dugumYapilari_sabit_ucret_max_kar.OrderByDescending(w => w.kar).ToArray();

            //_______________________________________________________________________


            // max kar işlemleri için DugumYapilari oluşturuluyor:
            // 10,20,30,40,50 adet yolcu için ayrı ayrı graf hazırlanıyor:
            DATA.dugumYapilari_degisken_ucret_50_kar = new DugumYapisi[5];
            for (int i = 1; i <= 5; i++)
            {
                DATA.dugumYapilari_degisken_ucret_50_kar[i - 1] = new DugumYapisi()
                {
                    dugumler = new Dugum[81],
                    yolcuSayisi = i * 10,
                    kar = 50
                };
            }
            // max kar çözüm işlemleri:
            for (int i = 0; i < DATA.dugumYapilari_degisken_ucret_50_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_degisken_ucret_50_kar[i];

                Islemler islemler = new Islemler();
                islemler.Coz(dugumYapisi);
            }
            // max kar çözüm işlemleri:
            for (int i = 0; i < DATA.dugumYapilari_degisken_ucret_50_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_degisken_ucret_50_kar[i];

                int olmasiGerekenKar = dugumYapisi.yolunZeplineMaliyeti * 3 / 2;
                dugumYapisi.kisiBasiPara = olmasiGerekenKar / dugumYapisi.yolcuSayisi;
            }
        }

        // form Baslagıç gizlendiğinden bu lazım oldu.
        private void Form_Baslangic_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
