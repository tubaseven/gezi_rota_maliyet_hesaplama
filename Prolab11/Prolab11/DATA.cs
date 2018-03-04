using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    class DATA
    {
        public static int baslangic_sehri_plaka_kodu { get; set; }
        public static int varis_sehri_plaka_kodu { get; set; }
        public static string verilenDosyalarinKlasoru { get; set; }
        public static int kisi_sayisi { get; set; }


        public static Dugum[] dugumler = new Dugum[81];


        public static void VerilenDosyalariYukle()
        {
            for (int i = 0; i < 81; i++)
            {
                DATA.dugumler[i] = new Dugum();
                DATA.dugumler[i].komsular = new List<Komsu>();
            }


            string plaka_ilAdi = DATA.verilenDosyalarinKlasoru + "/" + "plaka-il.txt";
            StreamReader oku = new StreamReader(plaka_ilAdi);
            string satir = oku.ReadLine();
            satir = oku.ReadLine(); // çünkü ilk satırda açıklama var
            while (satir != null)
            {
                string[] satirParcalari = satir.Split(',');
                string plakaKodu = satirParcalari[0];
                string sehirIsmi = satirParcalari[1];

                int plaka = Convert.ToInt32(plakaKodu);

                DATA.dugumler[plaka-1].plakaKodu = plaka;
                DATA.dugumler[plaka-1].isim = sehirIsmi;

                satir = oku.ReadLine();
            }
            oku.Close();



            // lat  long plakaKodu rakim
            string latlong = DATA.verilenDosyalarinKlasoru + "/" + "lat long.txt";
            StreamReader oku2 = new StreamReader(latlong);
            satir = oku2.ReadLine();
            satir = oku2.ReadLine(); // çünkü ilk satırda açıklama var
            while (satir != null)
            {
                string[] satirParcalari = satir.Split(',');
                string _lat = satirParcalari[0];
                string _long = satirParcalari[1];
                string _plakaKodu = satirParcalari[2];
                string _rakim = satirParcalari[3];

                int plaka = Convert.ToInt32(_plakaKodu);
                int rakim = Convert.ToInt32(_rakim);
                double lat = Convert.ToDouble(_lat.Replace('.', ','));
                double lng = Convert.ToDouble(_long.Replace('.',','));

                DATA.dugumler[plaka-1].rakim = rakim;
                DATA.dugumler[plaka-1].lat = lat;
                DATA.dugumler[plaka-1].lng = lng;

                satir = oku2.ReadLine();
            }
            oku2.Close();



            // plaka, pointX, pointY
            string plakaPoint = DATA.verilenDosyalarinKlasoru + "/" + "plaka-point.txt";
            StreamReader oku3 = new StreamReader(plakaPoint);
            satir = oku3.ReadLine();
            satir = oku3.ReadLine(); // çünkü ilk satırda açıklama var
            while (satir != null)
            {
                string[] satirParcalari = satir.Split(',');
                string _plakaKodu = satirParcalari[0];
                string _pointX = satirParcalari[1];
                string _pointY = satirParcalari[2];

                int plaka = Convert.ToInt32(_plakaKodu);
                int pointX = Convert.ToInt32(_pointX);
                int pointY = Convert.ToInt32(_pointY);

                DATA.dugumler[plaka-1].harita_X = pointX;
                DATA.dugumler[plaka-1].harita_Y = pointY;

                satir = oku3.ReadLine();
            }
            oku3.Close();



            // komşuluklar:
            string komsuluklar = DATA.verilenDosyalarinKlasoru + "/" + "Komşuluklar.txt";
            StreamReader oku4 = new StreamReader(komsuluklar);
            satir = oku4.ReadLine();
            satir = oku4.ReadLine(); // çünkü ilk satırda açıklama var
            while (satir != null)
            {
                string[] satirParcalari = satir.Split(',');
                string _plakaKodu = satirParcalari[0];

                // şu anki düğümün plakası
                int plaka = Convert.ToInt32(_plakaKodu);

                // plakak kodundan sonra gelen her numara bir  komşunu plakası
                for (int i = 1; i < satirParcalari.Length; i++)
                {
                    // komşu düğümün plakası
                    int komsu_plakaKodu = Convert.ToInt32(satirParcalari[i]);

                    // bir komşu nesnesi üretiliyor
                    Komsu komsu = new Komsu()
                    {
                        komsuDugum = DATA.dugumler[komsu_plakaKodu-1],
                        mesafe = 0
                    };

                    // şu anki düğüme komşu olarak ekleniyor
                    DATA.dugumler[plaka-1].komsular.Add(komsu);
                }

                satir = oku4.ReadLine();
            }
            oku4.Close();


        }
    }
}
