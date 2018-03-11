using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {


        static void Main(string[] args)
        {
            Dugum d1, d2, d3, d4, d5, d6;

            d1 = new Dugum() { isim = "A", deger = 99999999 };
            d2 = new Dugum() { isim = "B", deger = 99999999 };
            d3 = new Dugum() { isim = "C", deger = 99999999 };
            d4 = new Dugum() { isim = "D", deger = 99999999 };
            d5 = new Dugum() { isim = "E", deger = 99999999 };
            d6 = new Dugum() { isim = "F", deger = 99999999 };

            Kenar k12, k13, k34, k25, k26, k36, k46, k45;
            Kenar k21, k31, k43, k52, k62, k63, k64, k54;

            k12 = new Kenar() { ucDugum = d2, agirlik = 2 };
            k13 = new Kenar() { ucDugum = d3, agirlik = 1 };
            k34 = new Kenar() { ucDugum = d4, agirlik = 1 };
            k25 = new Kenar() { ucDugum = d5, agirlik = 2 };
            k26 = new Kenar() { ucDugum = d6, agirlik = 5 };
            k36 = new Kenar() { ucDugum = d6, agirlik = 2 };
            k46 = new Kenar() { ucDugum = d6, agirlik = 5 };
            k45 = new Kenar() { ucDugum = d5, agirlik = 7 };

            k21 = new Kenar() { ucDugum = d1, agirlik = 2 };
            k31 = new Kenar() { ucDugum = d1, agirlik = 1 };
            k43 = new Kenar() { ucDugum = d3, agirlik = 1 };
            k52 = new Kenar() { ucDugum = d2, agirlik = 2 };
            k62 = new Kenar() { ucDugum = d2, agirlik = 5 };
            k63 = new Kenar() { ucDugum = d3, agirlik = 2 };
            k64 = new Kenar() { ucDugum = d4, agirlik = 5 };
            k54 = new Kenar() { ucDugum = d4, agirlik = 7 };


            d1.kenarlar.Add(k12); d1.kenarlar.Add(k13);
            d2.kenarlar.Add(k25); d2.kenarlar.Add(k26);
            d3.kenarlar.Add(k34); d3.kenarlar.Add(k36);
            d4.kenarlar.Add(k45); d4.kenarlar.Add(k46);

            d2.kenarlar.Add(k21); d3.kenarlar.Add(k31);
            d5.kenarlar.Add(k52); d6.kenarlar.Add(k62);
            d4.kenarlar.Add(k43); d6.kenarlar.Add(k63);
            d5.kenarlar.Add(k54); d6.kenarlar.Add(k64);

            DijikstraCoz(d1, d5);

            foreach (Dugum dgm in d5.yollar)
            {
                Console.WriteLine(dgm.isim + ":" + dgm.deger);
            }

            Console.Read();
        }

        public static void DijikstraCoz(Dugum baslangicDugum, Dugum bitisDugum)
        {
            Dugum dugum = baslangicDugum;
            dugum.yollar.Add(dugum);
            dugum.deger = 0;

            Recursive(null, dugum);
        }

        public static void Recursive(Dugum parentDugum, Dugum dugum)
        {
            bool isChanged = false;
            for (int i = 0; i < dugum.kenarlar.Count; i++)
            {
                Kenar kenar = dugum.kenarlar.ElementAt(i);

                if (kenar.ucDugum == parentDugum)
                    continue;

                if (kenar.ucDugum.deger > (dugum.deger + kenar.agirlik))
                {
                    // yolları güncelle
                    if (parentDugum != null)
                    {
                        kenar.ucDugum.yollar.Clear();
                        kenar.ucDugum.yollar.AddRange(parentDugum.yollar.ToList());
                    }

                    kenar.ucDugum.yollar.Add(dugum);
                    kenar.ucDugum.yollar.Add(kenar.ucDugum);

                    kenar.ucDugum.deger = dugum.deger + kenar.agirlik;
                    isChanged = true;
                }
            }

            if (!isChanged)
                return;

            for (int i = 0; i < dugum.kenarlar.Count; i++)
            {
                Kenar kenar = dugum.kenarlar.ElementAt(i);

                if (kenar.ucDugum == parentDugum)
                    continue;

                Recursive(dugum, kenar.ucDugum);
            }
        }

    }

    class Dugum
    {
        public int deger { get; set; }
        public string isim { get; set; }
        public List<Kenar> kenarlar { get; set; }


        public List<Dugum> yollar { get; set; }

        public Dugum()
        {
            kenarlar = new List<Kenar>();
            yollar = new List<Dugum>();
        }
    }

    class Kenar
    {
        public int agirlik { get; set; }
        public Dugum ucDugum { get; set; }
    }

}
