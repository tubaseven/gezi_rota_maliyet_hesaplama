﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    class Islemler
    {

        public Islemler()
        {
            KomsuluklariKontrolEt();
        }

        public void Coz()
        {
            // djiskstra algoritması için başlangıç değerleri sonsuz olarak atanıyor:
            for (int i = 0; i < DATA.dugumler.Length; i++)
            {
                DATA.dugumler[i].toplamMaliyet = 1999999999;
            }

            // başlangıç ataması: başlangıç düğümüne değerleri atanıyor
            DATA.baslangic_sehri_plaka_kodu.yollar.Add(DATA.baslangic_sehri_plaka_kodu);
            DATA.baslangic_sehri_plaka_kodu.toplamMaliyet = 0;

            Recursive(null, DATA.baslangic_sehri_plaka_kodu);

            // çözüldü
        }

        public void KomsuluklariKontrolEt()
        {
            // zeplinin çıkacağı maximum açı:
            int maxZeplinAcisi = 80 - DATA.kisi_sayisi;

            foreach (Dugum dugum in DATA.dugumler)
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
                    int komsununUzakligiKM = Kodlar.GetDistanceAsKM(dugum.lat, dugum.lng, dugumunKomsusu.komsuDugum.lat, dugumunKomsusu.komsuDugum.lng);

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

        public static void Recursive(Dugum parentDugum, Dugum dugum)
        {
            bool isChanged = false;
            for (int i = 0; i < dugum.komsular.Count; i++)
            {
                Komsu kenar = dugum.komsular.ElementAt(i);

                if (kenar.komsuDugum == parentDugum)
                    continue;

                if (kenar.komsuDugum.toplamMaliyet > (dugum.toplamMaliyet + kenar.mesafe))
                {
                    // mesafe bilgisini güncelle
                    kenar.komsuDugum.toplamMaliyet = dugum.toplamMaliyet + kenar.mesafe;
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

    }
}
