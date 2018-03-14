using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    class Islemler
    {
        public void Coz(DugumYapisi dugumYapisi)
        {
            VerilenDosyalardanGrafOlustur(dugumYapisi);

            KomsuluklariKontrolEt(dugumYapisi);

            DjikstraEnKisaYoluBul(dugumYapisi);

            ZeplineMaliyetiBul(dugumYapisi);
        }

        public static void VerilenDosyalardanGrafOlustur(DugumYapisi dugumYapisi)
        {
            Dugum[] dugumler = dugumYapisi.dugumler;
            int kisi_sayisi = dugumYapisi.yolcuSayisi;

            for (int i = 0; i < 81; i++)
            {
                dugumler[i] = new Dugum();
                dugumler[i].komsular = new List<Komsu>();
                dugumler[i].yollar = new List<Dugum>();
            }

            string plaka_ilAdi = DATA.verilenDosyalarinKlasoru + "/" + "plaka-il.txt";
            StreamReader oku = new StreamReader(plaka_ilAdi, Encoding.GetEncoding(1254));
            string satir = oku.ReadLine();
            satir = oku.ReadLine(); // çünkü ilk satırda açıklama var
            while (satir != null)
            {
                string[] satirParcalari = satir.Split(',');
                string plakaKodu = satirParcalari[0];
                string sehirIsmi = satirParcalari[1];

                int plaka = Convert.ToInt32(plakaKodu);

                dugumler[plaka - 1].plakaKodu = plaka;
                dugumler[plaka - 1].isim = sehirIsmi;

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
                double lng = Convert.ToDouble(_long.Replace('.', ','));

                dugumler[plaka - 1].rakim = rakim;
                dugumler[plaka - 1].lat = lat;
                dugumler[plaka - 1].lng = lng;

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

                dugumler[plaka - 1].harita_X = pointX;
                dugumler[plaka - 1].harita_Y = pointY;

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
                        komsuDugum = dugumler[komsu_plakaKodu - 1],
                        mesafe = 0
                    };

                    // şu anki düğüme komşu olarak ekleniyor
                    dugumler[plaka - 1].komsular.Add(komsu);
                }

                satir = oku4.ReadLine();
            }
            oku4.Close();


        }

        public void KomsuluklariKontrolEt(DugumYapisi dugumYapisi)
        {
            Dugum[] dugumler = dugumYapisi.dugumler;
            int kisi_sayisi = dugumYapisi.yolcuSayisi;

            // zeplinin çıkacağı maximum açı:
            int maxZeplinAcisi = 80 - kisi_sayisi;

            foreach (Dugum dugum in dugumler)
            {
                // dugumun komsularından çıkarılacak olan komsuları tutacak olan liste:
                List<Komsu> silinecekDugumler = new List<Komsu>();

                for (int i = 0; i < dugum.komsular.Count; i++)
                {
                    bool gecebilirMi = false;

                    Komsu dugumunKomsusu = dugum.komsular.ElementAt(i);

                    // işlemler
                    int dugumRakim = dugum.rakim; // dugumun rakımı
                    int komsuRakimi = dugumunKomsusu.komsuDugum.rakim; // komsunun rakımı

                    // dugumler arası yatay uzaklık
                    int komsununUzakligiKM = DigerKodlar.GetDistanceAsKM(dugum.lat, dugum.lng, dugumunKomsusu.komsuDugum.lat, dugumunKomsusu.komsuDugum.lng);

                    int yatay_kenar = komsununUzakligiKM;
                    int dusey_kenar = Math.Abs(dugumRakim - (komsuRakimi + 40));
                    int hipotenus = (int)Math.Sqrt(Math.Pow((dusey_kenar * Math.Pow(10, -3)), 2) + Math.Pow(yatay_kenar, 2));

                    double aci = Math.Atan(((double)dusey_kenar) / yatay_kenar) * 180 / Math.PI;

                    dugumunKomsusu.mesafe = hipotenus;

                    // eğer zeplin yukarı çıkacaksa eğim limiti geçerli
                    if (dugumRakim < komsuRakimi)
                    {
                        if (aci <= maxZeplinAcisi)
                            gecebilirMi = true;
                        else
                            gecebilirMi = false;

                    }
                    else
                    {
                        gecebilirMi = true;
                    }


                    if (!gecebilirMi)
                    {
                        silinecekDugumler.Add(dugumunKomsusu);
                    }
                }

                // komsu olduğu halde gidilemeyecek komsular dugumun komsu listesinden çıkarılıyor:
                foreach (Komsu komsu in silinecekDugumler)
                {
                    dugum.komsular.Remove(komsu);
                }

            }
            // int a = 5; : breakpoint koyabilmek için :))
        }

        public void DjikstraEnKisaYoluBul(DugumYapisi dugumYapisi)
        {
            Dugum[] dugumler = dugumYapisi.dugumler;
            int kisi_sayisi = dugumYapisi.yolcuSayisi;

            // djiskstra algoritması için başlangıç değerleri sonsuz olarak atanıyor:
            for (int i = 0; i < dugumler.Length; i++)
            {
                dugumler[i].toplamYolKm = 1999999999;
            }

            Dugum baslangic_sehri_dugumu = dugumler[DATA.baslangic_sehri_plaka_kodu];
            Dugum varis_sehri_dugumu = dugumler[DATA.varis_sehri_plaka_kodu];

            // başlangıç ataması: başlangıç düğümüne değerleri atanıyor
            baslangic_sehri_dugumu.yollar.Add(baslangic_sehri_dugumu);
            baslangic_sehri_dugumu.toplamYolKm = 0;

            Recursive(null, baslangic_sehri_dugumu);
        }

        public void Recursive(Dugum parentDugum, Dugum dugum)
        {
            bool isChanged = false;
            for (int i = 0; i < dugum.komsular.Count; i++)
            {
                Komsu kenar = dugum.komsular.ElementAt(i);

                if (kenar.komsuDugum == parentDugum)
                    continue;

                if (kenar.komsuDugum.toplamYolKm > (dugum.toplamYolKm + kenar.mesafe))
                {
                    // mesafe bilgisini güncelle
                    kenar.komsuDugum.toplamYolKm = dugum.toplamYolKm + kenar.mesafe;
                    isChanged = true;

                    // yolları güncelle
                    if (parentDugum != null)
                    {
                        kenar.komsuDugum.yollar.Clear();
                        kenar.komsuDugum.yollar.AddRange(parentDugum.yollar.ToList());
                    }
                    kenar.komsuDugum.yollar.Add(dugum);
                    kenar.komsuDugum.yollar.Add(kenar.komsuDugum);
                }
            }

            if (!isChanged)
                return;

            for (int i = 0; i < dugum.komsular.Count; i++)
            {
                Komsu kenar = dugum.komsular.ElementAt(i);

                if (kenar.komsuDugum == parentDugum)
                    continue;

                Recursive(dugum, kenar.komsuDugum);
            }
        }

        public void ZeplineMaliyetiBul(DugumYapisi dugumYapisi)
        {
            Dugum[] dugumler = dugumYapisi.dugumler;

            Dugum varisDugumu = dugumler[DATA.varis_sehri_plaka_kodu];

            dugumYapisi.yolunZeplineMaliyeti = varisDugumu.toplamYolKm * 10;
        }
    }
}
