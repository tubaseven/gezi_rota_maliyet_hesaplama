using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab11
{
    public partial class Form_Chart : Form
    {
        public Form_Chart()
        {
            InitializeComponent();
        }

        private void Form_Chart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DATA.dugumYapilari_degisken_ucret_50_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_degisken_ucret_50_kar[i];

                // eğer çözüm bulundu ise:
                if (dugumYapisi.dugumler[DATA.varis_sehri_plaka_kodu].toplamYolKm != 1999999999)
                    comboBox_degiskenUCret.Items.Add(dugumYapisi.yolcuSayisi);
            }


            for (int i = 0; i < DATA.dugumYapilari_sabit_ucret_max_kar.Count(); i++)
            {
                DugumYapisi dugumYapisi = DATA.dugumYapilari_sabit_ucret_max_kar[i];

                // eğer çözüm bulundu ise:
                if (dugumYapisi.dugumler[DATA.varis_sehri_plaka_kodu].toplamYolKm != 1999999999)
                    comboBox_sabitUCret.Items.Add(dugumYapisi.yolcuSayisi);
            }
        }

        private void button_sabitUcret_Ciz_Click(object sender, EventArgs e)
        {
            // önceden çizilmiş yol silindi
            pictureBox1.Refresh();

            DugumYapisi dugumYapisi = DATA.dugumYapilari_sabit_ucret_max_kar.ToList().FirstOrDefault(w => w.yolcuSayisi == Convert.ToInt32(comboBox_sabitUCret.Text));
            Ciz(dugumYapisi);
        }

        private void button_degiskenUcret_Ciz_Click(object sender, EventArgs e)
        {
            // önceden çizilmiş yol silindi
            pictureBox1.Refresh();

            DugumYapisi dugumYapisi = DATA.dugumYapilari_degisken_ucret_50_kar.ToList().FirstOrDefault(w => w.yolcuSayisi == Convert.ToInt32(comboBox_degiskenUCret.Text));
            Ciz(dugumYapisi);
        }

        private void button_sabitUCret_Kaydet_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.EndsWith(".txt"))
                    saveFileDialog1.FileName += ".txt";

                Kaydet(DATA.dugumYapilari_sabit_ucret_max_kar, saveFileDialog1.FileName);
            }
        }

        private void button_degiskenUcret_Kaydet_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.EndsWith(".txt"))
                    saveFileDialog1.FileName += ".txt";

                Kaydet(DATA.dugumYapilari_degisken_ucret_50_kar, saveFileDialog1.FileName);
            }
        }

        private void Kaydet(DugumYapisi[] dugumYapilari, string kaydetmeYolu)
        {
            StreamWriter yaz = new StreamWriter(kaydetmeYolu);

            for (int j = 0; j < dugumYapilari.Length; j++)
            {
                DugumYapisi dugumYapisi = dugumYapilari[j];

                Dugum varis_sehri_plaka_kodu = dugumYapisi.dugumler[DATA.varis_sehri_plaka_kodu];

                // eğer çözüm bulunamadı ise:
                if (dugumYapisi.dugumler[DATA.varis_sehri_plaka_kodu].toplamYolKm == 1999999999)
                    continue;

                string text = "Toplam Yol: " + varis_sehri_plaka_kodu.toplamYolKm + " KM" + Environment.NewLine +
                    "ZeplineMAliyet: " + dugumYapisi.yolunZeplineMaliyeti + Environment.NewLine +
                    "Kar: " + dugumYapisi.kar + Environment.NewLine +
                    "Yolcu Sayısı: " + dugumYapisi.yolcuSayisi + Environment.NewLine +
                    "KisiBasi Para: " + dugumYapisi.kisiBasiPara + Environment.NewLine;

                Dugum oncekiDugum = null;
                for (int i = 0; i < varis_sehri_plaka_kodu.yollar.Count; i++)
                {
                    Dugum cozumAdimi = varis_sehri_plaka_kodu.yollar.ElementAt(i);

                    if (oncekiDugum != null)
                    {
                        text += " -> " + cozumAdimi.isim;
                    }
                    else
                    {
                        text += cozumAdimi.isim;
                    }

                    oncekiDugum = cozumAdimi;
                }

                yaz.WriteLine(text);
                yaz.WriteLine();
            }
            yaz.Close();

            MessageBox.Show("Dosyaya Yazıldı");
        }



        public void Ciz(DugumYapisi dugumYapisi)
        {
            Dugum varis_sehri_plaka_kodu = dugumYapisi.dugumler[DATA.varis_sehri_plaka_kodu];

            Pen kalem = new Pen(Color.Red, 4);
            Graphics cizim = pictureBox1.CreateGraphics();

            textBox_sonuc.Text = "Yolcu Sayısı: " + dugumYapisi.yolcuSayisi + " , " +
                                "Kar = " + dugumYapisi.kar + " , " +
                                "Toplam Yol = " + varis_sehri_plaka_kodu.toplamYolKm + " , " +
                                "Zepline Maliyet = " + dugumYapisi.yolunZeplineMaliyeti + " , " +
                                "Yolcu Başına Ücret = " + dugumYapisi.kisiBasiPara + Environment.NewLine;

            int cemberCapi = 40;
            Dugum oncekiDugum = null;
            for (int i = 0; i < varis_sehri_plaka_kodu.yollar.Count; i++)
            {
                Dugum cozumAdimi = varis_sehri_plaka_kodu.yollar.ElementAt(i);

                cizim.DrawEllipse(kalem, new Rectangle(cozumAdimi.harita_X - 20, cozumAdimi.harita_Y - 20, cemberCapi, cemberCapi));

                if (oncekiDugum != null)
                {
                    cizim.DrawLine(kalem, new Point(cozumAdimi.harita_X, cozumAdimi.harita_Y), new Point(oncekiDugum.harita_X, oncekiDugum.harita_Y));
                    textBox_sonuc.Text += " -> " + cozumAdimi.isim;
                }
                else
                {
                    textBox_sonuc.Text += cozumAdimi.isim;
                }

                oncekiDugum = cozumAdimi;
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Button btn = new Button();

            //btn.Left = e.X-15;
            //btn.Top = e.Y-15;

            //btn.Text = "X";
            //btn.BackColor = Color.Red;
            //btn.Size = new System.Drawing.Size(30, 30);

            //pictureBox1.Controls.Add(btn);

            //Nokta_Belirleyici nb = new Nokta_Belirleyici(new Point(e.X, e.Y));
            //nb.ShowDialog();            
        }

        private void Form_Chart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }






        //// daire çizdirme
        //cizim.DrawEllipse(kalem, new Rectangle(265, 300, 40, 40));
        //cizim.DrawEllipse(kalem, new Rectangle(352, 400, 40, 40));
        //cizim.DrawEllipse(kalem, new Rectangle(500, 350, 40, 40));
        //cizim.DrawEllipse(kalem, new Rectangle(400, 600, 40, 40));

        //// çizgi çizdirme
        //cizim.DrawLine(kalem, new Point(265 + 20, 300 + 20), new Point(352 + 20, 400 + 20));
        //cizim.DrawLine(kalem, new Point(352 + 20, 400 + 20), new Point(500 + 20, 350 + 20));
        //cizim.DrawLine(kalem, new Point(500 + 20, 350 + 20), new Point(400 + 20, 600 + 20));
    }
}
